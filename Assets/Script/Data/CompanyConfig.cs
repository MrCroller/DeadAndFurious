namespace DF.Data
{
    using UnityEngine;

    [CreateAssetMenu(fileName = nameof(CompanyConfig), menuName = "DR/Configs/Company")]
    public class CompanyConfig : ScriptableObject
    {
        [SerializeField]
        private CompanyEnum _company = default;
        [SerializeField]
        private Sprite _shipSprite = default;

        public CompanyEnum Company => _company;
        public Sprite ShipSprite => _shipSprite;
    }

    public enum CompanyEnum
    {
        Youndex = 0,
        Findmobile = 1,
        Luber = 2
    }
}
