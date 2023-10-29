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
        private EnemyInput _enemy = default;
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent<EnemyDeadZone>(out EnemyDeadZone findedCollider))
            {
                isMove = false;
                DisableEnemy();
            }
            if(collision.TryGetComponent<BulletInput>(out BulletInput bullet))
            {
                if(bullet._bulletSource == BulletSource.PlayerBullet)
                {
                    GetDamage(bullet.Damage);
                }
            }
        }

        private void GetDamage(int damage)
        {
            _enemy.HP -= damage;

            if (_enemy.HP <= 0)
            {
                _enemy.OnHPChange.Invoke(0, _enemy.MAXHP);
                Death();
            }
            else
            {
                _enemy.OnHPChange.Invoke(_enemy.HP, _enemy.MAXHP);
            }
        }

        private void FixedUpdate()
        {
            if (isMove)
            {
                _enemy.transform.position = new Vector3(_enemy.transform.position.x, _enemy.transform.position.y - _speed, 0);
            }
        }

        private IEnumerator Shoot()
        {
            _enemy.BulletSpawn.transform.LookAt(_enemy.Player.transform);
            yield return new WaitForSeconds(_enemyConfig.EnemyShootInterval);
        }

        private void DisableEnemy()
        {
            _enemy.EnemyObjectPool.AddToPool(_enemy);
        }

        private void Death()
        {
            OnDeath(_enemy.CarClass.ExpPoint);
            DisableEnemy();
        }
    }
}