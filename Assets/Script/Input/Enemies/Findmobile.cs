namespace DF.Input
{
    using DF.Controller;

    public sealed class Findmobile : Enemy
    {
        public override void InitController()
        {
            new FindmobileController(this);
        }
    }
}
