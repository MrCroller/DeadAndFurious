using UnityEngine;

namespace DF.Data
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "DR/Configs/Player")]
    public sealed class PlayerConfig : ScriptableObject
    {

        #region Fields

        [Tooltip("Скорость движения лодки")]
        [SerializeField] private float _speed = 5f;
        [Tooltip("Степень смягчения движения")]
        [SerializeField] private float _movementSmoothing = .05f;

        #endregion


        #region Properties

        public float Speed => _speed;
        public float MovementSmoothing => _movementSmoothing;

        #endregion

    }
}
