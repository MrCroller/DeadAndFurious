namespace DF.Input
{
    using UnityEngine;
    
    public class Bullet : MonoBehaviour
    {
        internal BulletSource _bulletSource = BulletSource.PlayerBullet;
        [SerializeField]
        private int _damage = default;

        public int Damage => _damage;
    }

    public enum BulletSource
    {
        EnemyBullet,
        PlayerBullet
    }
}
