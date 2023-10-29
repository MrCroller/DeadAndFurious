namespace DF.Input
{
    using DF.ObjectPool;
    using UnityEngine;
    
    public class BulletInput : MonoBehaviour
    {
        internal BulletSource bulletSource = BulletSource.PlayerBullet;
        internal ObjectPool<BulletInput> bulletPool = default;
        public Rigidbody2D Rigidbody;
        [SerializeField]
        private int _damage = default;

        public int Damage => _damage;

        private void OnValidate()
        {
            Rigidbody = Rigidbody != null ? Rigidbody : GetComponent<Rigidbody2D>();
        }
    }

    public enum BulletSource
    {
        EnemyBullet,
        PlayerBullet
    }
}
