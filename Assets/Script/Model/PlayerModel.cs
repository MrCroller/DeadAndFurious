using System.Collections.Generic;
using System.Linq;
using DF.Data;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;

namespace DF.Model
{
    internal class PlayerModel
    {
        #region Fields

        private const float MOV_SMOOTH_CUP = 0.1f;
        public readonly float LVLCup;

        private readonly float _baseHP;
        private readonly float _baseSpeed;
        private readonly float _baseMovementSmoothing;
        private readonly float _baseDamage;
        private readonly float _baseSpeedAtackDelay;

        internal readonly List<int> GradeMap;

        internal List<PassiveGradePlayer> Grades;
        internal NPCConfig CurrentNPC;
        internal GunConfig CurrentGun;

        internal bool IsGunReload;

        #endregion


        #region Properties

        public float HP { get; set; }

        public float MAXHP => _baseHP;

        public int XP { get; set; }

        public int XPNeed => LVL > GradeMap.Count ? GradeMap.Last() : GradeMap[LVL - 1];

        public int LVL { get; set; }

        public float CurrentSpeed
        {
            get => _baseSpeed + Grades.Sum(item => item.Speed);
        }

        public float CurrentMovementSmoothing
        {
            get
            {
                var value = _baseMovementSmoothing - Grades.Sum(item => item.MovementSmoothing);
                return value > MOV_SMOOTH_CUP ? value : MOV_SMOOTH_CUP;
            }
        }

        public float CurrentDamage
        {
            get => _baseDamage + Grades.Sum(item => item.Damage) + CurrentGun.Bullet.Damage;
        }

        public float CurrentSpeedAtack
        {
            get => _baseSpeedAtackDelay - Grades.Sum(item => item.SpeedAtackDelay) + CurrentGun.AttackDelay;
        }

        #endregion

        internal PlayerModel(PlayerConfig config)
        {
            HP = config.HP;

            _baseHP = config.HP;
            _baseSpeed = config.Speed;
            _baseMovementSmoothing = config.MovementSmoothing;
            _baseDamage = config.Damage;
            _baseSpeedAtackDelay = config.SpeedAtackDelay;

            CurrentGun = config.DefaultGun;
            IsGunReload = false;

            GradeMap = config.LevelGradeMap.Map.ToList();
            Grades = new();
            LVLCup = config.LevelCup;
        }
    }
}
