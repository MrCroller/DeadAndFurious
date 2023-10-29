using TimersSystemUnity.Extension;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineTimers;

namespace DF.UI
{
    public class HPSlider : MonoBehaviour
    {
        [SerializeField] private float _animTime;
        [SerializeField] private float _waitAnimTime;

        [SerializeField] private Slider _hpBar;
        [SerializeField] private Image _sliderBack;
        [SerializeField] private Image _sliderFill;

        private TimersPool _pool;
        private IStop _timer = null;
        private float _saveNormalizeValue;

        private void Start()
        {
            _pool = TimersPool.GetInstance();

            _sliderBack.SetAlpha(0f);
            _sliderFill.SetAlpha(0f);
        }

        private void Reset()
        {
            _hpBar = _hpBar != null ? _hpBar : GetComponent<Slider>();
        }

        /// <summary>
        /// Изменяет хп с анимацией
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxHP"></param>
        public void OnHpChangeHandler(float value, float maxHP)
        {
            if (_timer != null)
            {
                _timer.Stop();
                _hpBar.value = _saveNormalizeValue;

                _sliderBack.SetAlpha(1f);
                _sliderFill.SetAlpha(1f);
            }
            else
            {
                _timer = _pool.StartTimer((float progress) =>
                {
                    _sliderBack.SetAlpha(progress);
                    _sliderFill.SetAlpha(progress);

                }, _animTime);
            }

            var normalizeValue = value / maxHP;

            _timer = _pool.StartTimer(Wait, (float progress) =>
            {
                _hpBar.value = Mathf.Lerp(_saveNormalizeValue, normalizeValue, progress);
            }, _animTime);

            void Wait()
            {
                _saveNormalizeValue = normalizeValue;
                _timer = _pool.StartTimer(BarClose, _waitAnimTime);
            }

            void BarClose()
            {
                _timer = _pool.StartTimer(() => _timer = null, (float progress) =>
                {
                    _sliderBack.SetAlpha(1f - progress);
                    _sliderFill.SetAlpha(1f - progress);
                }, _animTime);
            }
        }
    }
}
