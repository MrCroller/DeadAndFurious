namespace DF.Controller
{
    using DF.Data;
    using DF.Input;
    using System.Collections;
    using UnityEngine;

    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private Enemy _enemy = default;
        protected bool isMove = true;

        private float _speed;
        private EnemyConfig _enemyConfig;

        private void Start()
        {
            _enemyConfig = _enemy.EnemyConfig;
            _speed = _enemyConfig.EnemySpeed;
            StartCoroutine(Shoot());
        }

        protected void FixedUpdate()
        {
            _enemy.transform.position = new Vector3(_enemy.transform.position.x, _enemy.transform.position.y - _speed, 0);
            if (_enemy.transform.position.y < 0 - Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0)).y - _enemy.transform.localScale.y)
            {
                DisableEnemy();
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
    }
}