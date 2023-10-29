using DF.Interface;
using UnityEngine;

namespace DF.Data
{
    [CreateAssetMenu(fileName = "NPC", menuName = "DF/Configs/Grade/NPC")]
    public class NPCConfig : ScriptableObject, ISkillInfo
    {
        #region Fields

        [SerializeField] private Sprite _icon;
        [SerializeField] private string _name;
        [SerializeField] private string _description;

        #endregion


        #region Properties

        public Sprite Icon => _icon;
        public string Name => _name;
        public string Description => _description;

        #endregion
    }
}
