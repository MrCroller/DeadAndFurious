namespace DF.Input
{
    using DF.Data;
    using UnityEngine;

    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _enemySprite = default;
        private CarClassConfig _carClass;
        private CompanyConfig _company;

        public CarClassConfig CarClass => _carClass;
        public CompanyConfig Company => _company;

        public void SetCarClassConfig(CarClassConfig carClassConfig)
        {
            _carClass = carClassConfig;
        }

        public void SetCompanyConfig(CompanyConfig companyconfig)
        {
            _company = companyconfig;
        }

        public void UpdateVisual()
        {
            _enemySprite.sprite = _company.ShipSprite;
            this.gameObject.transform.localScale = Vector3.one * CarClass.ScaleFactor;
        }
    }
}
