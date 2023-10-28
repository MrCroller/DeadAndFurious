namespace DF.Data
{
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(CarClassConfig), menuName = "DF/Configs/CarClass")]
    public class CarClassConfig : ScriptableObject
    {
        [SerializeField]
        private CarClassesEnum _carClass = default;
        [SerializeField]
        private Sprite _shipSprite = default;
        [SerializeField, Header("Очки опыта")]
        private int _expPoint = default;

        public CarClassesEnum CarClass => _carClass;
        public Sprite ShipSprite => _shipSprite;
        public int ExpPoint => _expPoint;
    }

    public enum CarClassesEnum
    {
        Econom = 0,
        Comfort = 1,
        ComfortPlus = 2
    }
}
