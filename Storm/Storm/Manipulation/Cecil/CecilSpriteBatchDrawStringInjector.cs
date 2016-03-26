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
                    count++;
                }
            }
        }
    }
}
