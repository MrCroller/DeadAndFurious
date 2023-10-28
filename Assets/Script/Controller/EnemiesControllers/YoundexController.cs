namespace DF.Controller
{
    using DF.Input;

    public sealed class YoundexController : EnemyController
    {
        public YoundexController(Youndex go)
        {
            _enemyGO = go;
            StartMovement();
        }
    }
}
