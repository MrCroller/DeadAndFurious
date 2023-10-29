using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineTimers;

namespace DF.UI
{
    internal class ExpManager : MonoBehaviour
    {
        [SerializeField] private Slider _expSlider;
        [SerializeField] private TMP_Text _lvlText;

        [SerializeField] private float _animTime;

        private float _saveValue;
        private float _newValue;
        private IStop _timer;

        public void OnExpChangeHandler(float exp, float expNextlevel)
        {
            if (_timer != null)
            {
                _timer.Stop();
                _expSlider.value = _newValue;
                _saveValue = _newValue;
            }
            _newValue = exp / expNextlevel;

            _timer = TimersPool.GetInstance().StartTimer(
                () => { _timer = null; _saveValue = _newValue; }, 
                (float progress) =>
            {
                _expSlider.value = Mathf.Lerp(_saveValue, exp, progress);
            }, _animTime);
        }

        public void OnLVLChange(int lvl)
        {
            _lvlText.text = lvl.ToString();


        }
    }
}
