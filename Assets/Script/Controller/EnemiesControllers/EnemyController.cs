namespace DF.Controller
{
    using DF.Data;
    using DF.Input;
    using System;
    using System.Collections;
    using UnityEngine;

    public class EnemyController : MonoBehaviour
    {
        /// <summary>
        /// Ивент, который вызывается, когда кто-либо из врагов умер
        /// </summary>
        public static event Action<int> OnDeath = delegate { };

        [SerializeField]
        private Enemy _enemy = default;
        private bool isMove = true;

        private float _speed;
        private EnemyConfig _enemyConfig;

        private void OnEnable()
        {
            isMove = true;
            _enemyConfig = _enemy.EnemyConfig;
            _speed = _enemyConfig.EnemySpeed;
            //StartCoroutine(Shoot());
        }

        private void FixedUpdate()
        {
            if (isMove)
            {
                _enemy.transform.position = new Vector3(_enemy.transform.position.x, _enemy.transform.position.y - _speed, 0);
                if (_enemy.transform.position.y < 0 - Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y - _enemy.transform.localScale.y)
                {
                    isMove = false;
                    DisableEnemy();
                }
            }
        }

        private IEnumerator Shoot()
        {
            yield return new WaitForSeconds(_enemyConfig.EnemyShootInterval);
        }

        private void DisableEnemy()
        {
            _enemy.EnemyObjectPool.AddToPool(_enemy);
        }

        public void GetDamage(int damage)
        {
            //получить урон
            //Если хп <=0, то умереть
        }

        private void Death()
        {
            OnDeath(_enemy.CarClass.ExpPoint);
            DisableEnemy();
        }
    }
}