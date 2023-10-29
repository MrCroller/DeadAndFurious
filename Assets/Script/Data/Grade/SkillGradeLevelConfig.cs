using DF.Interface;
using UnityEngine;

namespace DF.Data
{
    [CreateAssetMenu(fileName = nameof(SkillGradeLevelConfig), menuName = "DF/Configs/Grade/SkillLevelMap")]
    public class SkillGradeLevelConfig : ScriptableObject
    {

        #region Fields

        [SerializeField] private ISkillInfo[] _attackGrade;
        [SerializeField] private ISkillInfo[] _npc;
        [SerializeField] private ISkillInfo[] _movementGrade;

        #endregion


        #region Properties

        public ISkillInfo[] AttackGrade => _attackGrade;
        public ISkillInfo[] NPC => _npc;
        public ISkillInfo[] MovementGrade => _movementGrade;

        #endregion

    }
}
