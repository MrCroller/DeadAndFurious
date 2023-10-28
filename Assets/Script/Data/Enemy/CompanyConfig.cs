namespace DF.Data
{
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(CompanyConfig), menuName = "DF/Configs/Enemy/Company")]
    public class CompanyConfig : ScriptableObject
    {
        [SerializeField]
        private CompanyEnum _company = default;

        public CompanyEnum Company => _company;
    }

    public enum CompanyEnum
    {
        Youndex = 0,
        Findmobile = 1,
        Luber = 2
    }
}
