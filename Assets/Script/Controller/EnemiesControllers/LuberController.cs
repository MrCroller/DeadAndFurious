namespace DF.Controller
{
    using DF.Input;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LuberController : EnemyController
    {
        private Luber _luberGO = default;

        public LuberController(Luber go)
        {
            _luberGO = go;
        }
    }
}
