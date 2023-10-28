namespace DF.Controller
{
    using DF.Input;
    using System.Collections;
    using UnityEngine;
    using UnityEngineTimers;

    public abstract class EnemyController
    {
        protected Enemy _enemyGO = default;
        protected bool isMove = true;

        private float _speed;

        protected void StartMovement()
        {
            _speed = _enemyGO.EnemyConfig.Speed;
            Coroutines.StartRoutine(MovementCoroutine());
        }

        private IEnumerator MovementCoroutine()
        {
            while (isMove)
            {
                yield return new WaitForFixedUpdate();
                _enemyGO.transform.position = new Vector3(_enemyGO.transform.position.x, _enemyGO.transform.position.y - _speed, 0);
            }
        }
    }
}