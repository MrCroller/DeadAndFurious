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
        private Enemy _shipPrefab = default;
        [SerializeField, Header("Очки опыта")]
        private int _expPoint = default;
        [SerializeField, Header("ХП")]
        private int _HP = default;

        public CarClassesEnum CarClass => _carClass;
        public Enemy ShipPrefab => _shipPrefab;
        public int ExpPoint => _expPoint;
        public int HP => _HP;
    }

    public enum CarClassesEnum
    {
        Econom = 0,
        Comfort = 1,
        Business = 2
    }
}
