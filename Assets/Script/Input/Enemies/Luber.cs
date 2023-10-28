using DF.Controller;

namespace DF.Input
{
    public sealed class Luber : Enemy
    {
        public override void InitController()
        {
            new LuberController(this);
        }
    }
}
