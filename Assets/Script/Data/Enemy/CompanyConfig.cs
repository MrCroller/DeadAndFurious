namespace DF.Data
{
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(CompanyConfig), menuName = "DF/Configs/Enemy/Company")]
    public class CompanyConfig : ScriptableObject
    {
        [SerializeField]
        private CompanyEnum _company = default;
        [SerializeField]
        private Color _companyColor = default;
        [SerializeField]
        private Sprite _managerSprite = default;

        public CompanyEnum Company => _company;
        public Color CompanyColor => _companyColor; 
        public Sprite ManagerSprite => _managerSprite;  
    }

    public enum CompanyEnum
    {
        Youndex = 0,
        Findmobile = 1,
        Luber = 2
    }
}
