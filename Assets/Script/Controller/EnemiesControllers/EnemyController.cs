namespace DF.Controller
{
    using DF.Data;
    using DF.Input;
    using DF.ObjectPool;
    using System;
    using System.Collections;
    using UnityEngine;

    public class EnemyController : MonoBehaviour
    {
        /// <summary>
        /// Ивент, который вызывается, когда кто-либо из врагов умер
        /// </summary>
        public static event Action<int> OnDeath = delegate { };

        private EnemyInput _enemy = default;
        private bool isMove = true;

        private float _speed;
        private EnemyConfig _enemyConfig;

        private ObjectPool<BulletInput> _bulletPool;

        private Coroutine _shootCoroutine = default;

        public void Init(EnemyInput enemy)
        {
            _enemy = enemy;
            isMove = true;
            _enemyConfig = _enemy.EnemyConfig;
            _speed = _enemyConfig.EnemySpeed;
            _bulletPool = _enemy.BulletPool;
            if(_shootCoroutine != null)
            {
                StopCoroutine(_shootCoroutine);
            }
            if (_enemy.CarClass.IsShoot)
            {
                _shootCoroutine = StartCoroutine(Shoot());
            }
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
                if(bullet.bulletSource == BulletSource.PlayerBullet)
                {
                    GetDamage(bullet.Damage);
                    bullet.bulletPool.AddToPool(bullet);
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
            BulletInput bullet = _bulletPool.GetObjectFromPool(_enemy.EnemyConfig.Weapon.Bullet, _enemy.EnemyConfig.Weapon.BulletLifeTime);
            bullet.bulletPool = _bulletPool;
            bullet.transform.position = _enemy.BulletSpawn.position;
            bullet.bulletSource = BulletSource.EnemyBullet;
            Rigidbody2D bulletRb = bullet.Rigidbody;
            Vector2 direction = _enemy.Player.gameObject.transform.position - _enemy.BulletSpawn.transform.position;
            bulletRb.AddForce(direction * _enemy.EnemyConfig.Weapon.FireForse, ForceMode2D.Impulse);

            yield return new WaitForSeconds(_enemyConfig.Weapon.AttackDelay);
        }

        private void DisableEnemy()
        {
            _enemy.EnemyObjectPool.AddToPool(_enemy);
            if (_shootCoroutine != null)
            {
                StopCoroutine(_shootCoroutine);
            }
            _shootCoroutine = null;
        }

        private void Death()
        {
            OnDeath(_enemy.CarClass.ExpPoint);
            DisableEnemy();
        }
        private void OnDestroy()
        {
            if (_shootCoroutine != null)
            {
                StopCoroutine(_shootCoroutine);
            }
            _shootCoroutine = null;
        }
    }
}