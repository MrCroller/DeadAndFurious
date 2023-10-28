using DF.Data;

namespace DF.Model
{
    internal class PlayerModel
    {
        #region Fields

        private readonly float _baseSpeed;
        private readonly float _baseMovementSmoothing;
        private readonly float _baseDamage;
        private readonly float _baseSpeedAtack;

        internal float AdditionalSpeed;
        internal float AdditionalMovementSmoothing;
        internal float AdditionalDamage;
        internal float AdditionalSpeedAtack;

        internal GunConfig CurrentGun;
        internal bool IsGunReload;

        #endregion


        #region Properties

        public float CurrentSpeed
        {
            get => _baseSpeed + AdditionalSpeed;
        }

        public float CurrentMovementSmoothing
        {
            get => _baseMovementSmoothing + AdditionalMovementSmoothing;
        }

        public float CurrentDamage
        {
            get => _baseDamage + AdditionalDamage + CurrentGun.Damage;
        }

        public float CurrentSpeedAtack
        {
            get => _baseSpeedAtack + AdditionalSpeedAtack + CurrentGun.AttackDelay;
        }

        #endregion

        internal PlayerModel(PlayerConfig config)
        {
            _baseSpeed = config.Speed;
            _baseMovementSmoothing = config.MovementSmoothing;
            _baseDamage = config.Damage;
            _baseSpeedAtack = config.SpeedAtack;

            CurrentGun = config.DefaultGun;
            IsGunReload = false;
        }
    }
}
