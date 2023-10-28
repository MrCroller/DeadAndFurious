namespace DF.Controller
{
    using DF.Input;

    public sealed class FindmobileController : EnemyController
    {
        public FindmobileController(Findmobile go)
        {
            _enemyGO = go;
            StartMovement();
        }
    }
}
