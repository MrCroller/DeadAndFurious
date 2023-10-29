using UnityEngine;

namespace DF.Data
{
    [CreateAssetMenu(fileName = nameof(SkillGradeLevelConfig), menuName = "DF/Configs/Grade/SkillLevelMap")]
    public class SkillGradeLevelConfig : ScriptableObject
    {
        #region Fields

        [SerializeField] private PassiveGradePlayer[] _attackGrade;
        [SerializeField] private NPCConfig[] _npc;
        [SerializeField] private PassiveGradePlayer[] _movementGrade;

        #endregion


        #region Properties

        public PassiveGradePlayer[] AttackGrade => _attackGrade;
        public NPCConfig[] NPC => _npc;
        public PassiveGradePlayer[] MovementGrade => _movementGrade;

        #endregion

    }
}
