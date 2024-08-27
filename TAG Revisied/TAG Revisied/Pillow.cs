using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_Revisied

{
    public class Pillow : Item
    {
        public Pillow() : base("PILLOW","Fluffy, but smelly.",false) { }
        public override string Use(GameState gameState)
        {
            return "I'd rather not put my head on that.";
        }
    }
}
