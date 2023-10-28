namespace DF.Controller
{
    using DF.Input;

    public sealed class LuberController : EnemyController
    {
        public LuberController(Luber go)
        {
            _enemyGO = go;
            StartMovement();
        }
    }
}
