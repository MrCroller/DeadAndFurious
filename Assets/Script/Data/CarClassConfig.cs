namespace DF.Data
{
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(CarClassConfig), menuName = "DR/Configs/CarClass")]
    public class CarClassConfig : ScriptableObject
    {
        [SerializeField]
        private CarClassesEnum _carClass = default;
        [SerializeField, Min(0)]
        private float _scaleFactor = default;

        public CarClassesEnum CarClass => _carClass;
        public float ScaleFactor => _scaleFactor;
    }

    public enum CarClassesEnum
    {
        Econom = 0,
        Comfort = 1,
        ComfortPlus = 2
    }
}
