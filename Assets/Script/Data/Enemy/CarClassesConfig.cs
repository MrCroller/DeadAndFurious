namespace DF.Data
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(CarClassesConfig), menuName = "DF/Configs/Enemy/CarClasses")]
    public class CarClassesConfig : ScriptableObject
    {
        [SerializeField]
        private List<CarClassConfig> _carClasses = new List<CarClassConfig>();

        public List<CarClassConfig> CarClasses => _carClasses;
    }
}
