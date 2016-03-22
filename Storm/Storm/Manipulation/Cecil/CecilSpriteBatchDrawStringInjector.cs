using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using Storm.StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Manipulation.Cecil
{
    public class CecilSpriteBatchDrawStringInjector : Injector
    {
        private readonly AssemblyDefinition def;
        private readonly AssemblyDefinition self;
        private List<MethodDefinition> injectees;
        private MethodReference FullCallback;
        private MethodReference ShortCallback;

        public CecilSpriteBatchDrawStringInjector(AssemblyDefinition self, AssemblyDefinition def)
        {
            this.self = self;
            this.def = def;
        }

        public object GetParams()
        {
            return null;
        }

        public void Init()
        {
            injectees = def.Modules.SelectMany(mod => ModuleDefinitionRocks.GetAllTypes(mod))
                .SelectMany(t => t.Methods)
                .Where(method => null != method.Body).ToList();

            //var CallbackMethods = typeof(StaticGameContext).GetMethods(System.Reflection.BindingFlags.)
            var FullCallbackMethod = typeof(StaticGameContext).GetMethod("SpriteBatchDrawStringCallback", new Type[] { typeof(SpriteBatch),
            typeof(SpriteFont),typeof(string),typeof(Vector2),typeof(Color),typeof(float),typeof(Vector2),typeof(float),typeof(SpriteEffects),typeof(float)});
            FullCallback = def.MainModule.Import(FullCallbackMethod);
            var ShortCallbackMethod = typeof(StaticGameContext).GetMethod("SpriteBatchDrawStringCallback", new Type[] { typeof(SpriteBatch),
            typeof(SpriteFont),typeof(string),typeof(Vector2),typeof(Color) });
            ShortCallback = def.MainModule.Import(ShortCallbackMethod);
        }

        public void Inject()
        {
            int count = 0;
            foreach (var body in injectees.Select(m => m.Body))
            {
                var processor = body.GetILProcessor();
                var instructions = body.Instructions.Where(instr => instr.OpCode == OpCodes.Callvirt && instr.ToString().Contains("SpriteBatch::DrawString")).ToList();
                foreach (var instr in instructions)
                {
                    //var callInstructions = new List<Instruction>();
                    var meth = instr.Operand as MethodReference;
                    if(meth.Parameters.Count == 9)
                    {
                        var writeInstruction = processor.Create(OpCodes.Call, FullCallback);
                        processor.Replace(instr, writeInstruction);
                    }
                    else if(meth.Parameters.Count == 4)
                    {
                        var writeInstruction = processor.Create(OpCodes.Call, ShortCallback);
                        processor.Replace(instr, writeInstruction);
                    }
                    //var instructionsCall = GetAllMethodInstructions(instr);
                    //var stringEndArg = GetStringArgument(instr, callInstructions);
                    count++;
                }
            }
        }

        public List<Instruction> GetAllMethodInstructions(Instruction callMethodInstruction)
        {
            var result = new List<Instruction>();
            if (callMethodInstruction.OpCode == OpCodes.Call ||
                callMethodInstruction.OpCode == OpCodes.Calli ||
                callMethodInstruction.OpCode == OpCodes.Callvirt)
            {
                var prevInstruction = callMethodInstruction.Previous;
                //while (true)
                //{
                //    result.Add(prevInstruction);
                //    if (prevInstruction.OpCode == OpCodes.new)
                //    {
                //        break;
                //    }
                //    else prevInstruction = prevInstruction.Previous;
                //}
            }
            return result;
        }

        public Instruction GetStringArgument(Instruction callDrawString, List<Instruction> callInstructions)
        {
            callInstructions.Add(callDrawString.Previous);
            if (callDrawString.Previous.OpCode == OpCodes.Ldstr || callDrawString.Previous.OpCode == OpCodes.Ldarg_1 ||
                (callDrawString.Previous.OpCode == OpCodes.Call && callDrawString.Previous.ToString().Contains("System.String::")) ||
                (callDrawString.Previous.OpCode == OpCodes.Callvirt && callDrawString.Previous.ToString().Contains("System.String::")) ||
                (callDrawString.Previous.OpCode == OpCodes.Callvirt && callDrawString.Previous.ToString().Contains("Generic.List`1<System.String>::get_Item")) ||
                (callDrawString.Previous.OpCode == OpCodes.Callvirt && callDrawString.Previous.ToString().Contains("Generic.Dictionary`2<") && callDrawString.Previous.ToString().Contains("System.String>::get_Item")) ||
                ((callDrawString.Previous.Operand as ParameterReference) != null && (callDrawString.Previous.Operand as ParameterReference).ParameterType.FullName == typeof(string).FullName) ||
                ((callDrawString.Previous.Operand as FieldReference) != null && (callDrawString.Previous.Operand as FieldReference).FieldType.FullName == typeof(string).FullName) ||
                ((callDrawString.Previous.Operand as PropertyReference) != null && (callDrawString.Previous.Operand as PropertyReference).PropertyType.FullName == typeof(string).FullName))
            {
                return callDrawString.Previous;
            }
            else
            {
                return GetStringArgument(callDrawString.Previous, callInstructions);
            }
        }
    }
}
