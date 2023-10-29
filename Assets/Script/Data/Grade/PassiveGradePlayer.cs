using System.Collections.Generic;
using System.Text;
using DF.Interface;
using UnityEngine;


namespace DF.Data
{
    [CreateAssetMenu(fileName = nameof(PassiveGradePlayer), menuName = "DF/Configs/Grade/Passive")]
    public class PassiveGradePlayer : ScriptableObject, ISkillInfo
    {
        #region Fields

        [Tooltip("Иконка грейда")]
        [SerializeField] private Sprite _icon;
        [Tooltip("Название")]
        [SerializeField] private string _name;


        [Tooltip("Скорость движения лодки")]
        [SerializeField] private float _speed;
        [Tooltip("Степень смягчения движения")]
        [SerializeField] private float _movementSmoothing;
        [Tooltip("Базовый урон")]
        [SerializeField] private float _damage;
        [Tooltip("На сколько уменьшется базовая задержка перед выстрелами")]
        [SerializeField] private float _speedAtackDelay;


        #endregion


        #region Properties

        public Sprite Icon => _icon;
        public string Name => _name;

        public float Speed => _speed;
        public float MovementSmoothing => _movementSmoothing;
        public float Damage => _damage;
        public float SpeedAtackDelay => _speedAtackDelay;

        public string Description
        {
            get
            {
                StringBuilder description = new();

                if (Speed > 0) description.Append($"Скорость +{Speed}\n");
                if (MovementSmoothing > 0) description.Append($"Резвость +{MovementSmoothing}\n");
                if (Damage > 0) description.Append($"Урон +{Damage}\n");
                if (SpeedAtackDelay > 0) description.Append($"Скорость атаки +{SpeedAtackDelay}\n");

                return description.ToString();
            }
        }

        #endregion
    }
}
