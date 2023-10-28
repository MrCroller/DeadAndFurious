using DF.Input;

namespace DF.Controller
{
    public class YoundexController : EnemyController
    {
        private Youndex _youndexGO = default;

        public YoundexController(Youndex go)
        {
            _youndexGO = go;
        }
    }
}
