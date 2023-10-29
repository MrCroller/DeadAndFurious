using System.Collections.Generic;
using UnityEngine;

namespace DF.Data
{
    [CreateAssetMenu(fileName = nameof(PlayerExpLevelGradeConfig), menuName = "DF/Configs/Grade/ExpLevelMap")]
    public class PlayerExpLevelGradeConfig : ScriptableObject
    {
        #region Fields

        [Tooltip("Карта необходимого опыта для уровня. Индекс элемента = лвл - 1")]
        [SerializeField] private List<int> _upGradeMap;


        #endregion


        #region Properties

        public IReadOnlyCollection<int> Map => _upGradeMap;

        #endregion
    }
}
