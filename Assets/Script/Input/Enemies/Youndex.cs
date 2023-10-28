using DF.Controller;

namespace DF.Input
{
    public sealed class Youndex : Enemy
    {
        public override void InitController()
        {
            new YoundexController(this);
        }
    }
}
