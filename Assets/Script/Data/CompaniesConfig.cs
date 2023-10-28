namespace DF.Data
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(CompaniesConfig), menuName = "DF/Configs/Companies")]
    public class CompaniesConfig : ScriptableObject
    {
        [SerializeField]
        private List<CompanyConfig> _companies = new List<CompanyConfig>();

        public List<CompanyConfig> Companies => _companies;
    }
}
