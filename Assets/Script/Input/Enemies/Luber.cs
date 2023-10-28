using DF.Controller;

namespace DF.Input
{
    public class Luber : Enemy
    {
        public override void InitController()
        {
            new LuberController(this);
        }
    }
}
