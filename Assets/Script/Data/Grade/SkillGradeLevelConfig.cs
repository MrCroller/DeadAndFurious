using DF.Interface;
using UnityEngine;

namespace DF.Data
{
    [CreateAssetMenu(fileName = nameof(SkillGradeLevelConfig), menuName = "DF/Configs/Grade/SkillLevelMap")]
    public class SkillGradeLevelConfig : ScriptableObject
    {

        #region Fields

        [SerializeField] private PassiveGradePlayer[] _attackGrade;
        [SerializeField] private GunConfig[] _attackGradeGun;
        [SerializeField] private NPCConfig[] _npc;
        [SerializeField] private PassiveGradePlayer[] _movementGrade;

        #endregion


        #region Properties

        public ISkillInfo[] AttackGrade => _attackGrade;
        public ISkillInfo[] GunGrade => _attackGradeGun;
        public ISkillInfo[] NPC => _npc;
        public ISkillInfo[] MovementGrade => _movementGrade;

        #endregion

    }
}
