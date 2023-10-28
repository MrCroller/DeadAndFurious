using DF.Controller;

namespace DF.Input
{
    public class Findmobile : Enemy
    {
        public override void InitController()
        {
            new FindmobileController(this);
        }
    }
}
