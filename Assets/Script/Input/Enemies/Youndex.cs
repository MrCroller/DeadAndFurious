using DF.Controller;

namespace DF.Input
{
    public class Youndex : Enemy
    {
        public override void InitController()
        {
            new YoundexController(this);
        }
    }
}
