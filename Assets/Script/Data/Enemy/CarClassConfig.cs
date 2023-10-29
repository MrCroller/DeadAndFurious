namespace DF.Data
{
    using DF.Input;
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(CarClassConfig), menuName = "DF/Configs/Enemy/CarClass")]
    public class CarClassConfig : ScriptableObject
    {
        [SerializeField]
        private CarClassesEnum _carClass = default;
        [SerializeField]
        private EnemyInput _shipPrefab = default;
        [SerializeField, Header("Очки опыта")]
        private int _expPoint = default;
        [SerializeField, Header("ХП")]
        private int _HP = default;
        [SerializeField, Header("Может ли стрелять")]
        private bool _isShoot = default;

        public CarClassesEnum CarClass => _carClass;
        public EnemyInput ShipPrefab => _shipPrefab;
        public int ExpPoint => _expPoint;
        public int HP => _HP;
        public bool IsShoot => _isShoot;
    }

    public enum CarClassesEnum
    {
        Econom = 0,
        Comfort = 1,
        Business = 2
    }
}
