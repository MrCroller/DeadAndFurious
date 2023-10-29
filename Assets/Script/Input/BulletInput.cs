namespace DF.Input
{
    using UnityEngine;
    
    public class BulletInput : MonoBehaviour
    {
        internal BulletSource _bulletSource = BulletSource.PlayerBullet;
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
