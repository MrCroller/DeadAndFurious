using System.Text;
using DF.Data;
using DF.Extension;
using DF.Interface;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngineTimers;

namespace DF.UI
{
    internal class ExpManager : MonoBehaviour
    {
        [SerializeField] private Slider _expSlider;
        [SerializeField] private TMP_Text _lvlText;
        [SerializeField] private float _animTime;
        [Header("Скиллы и уровень")]
        [SerializeField] private Transform _skillPanel;

        [SerializeField] private SkillUI _attackSkill;
        [SerializeField] private SkillUI _npsSlot;
        [SerializeField] private SkillUI _moveSkill;

        [SerializeField] private SkillGradeLevelConfig GradeMap;

        public UnityEvent<ISkillInfo> OnSelect;

        private float _saveValue;
        private float _saveLVL;
        private float _newValue;
        private IStop _timer;

        private void Awake()
        {
            _attackSkill.Button.onClick.AddListener(() => 
            { 
                OnSelect.Invoke(_attackSkill.SelectSkill); 
                _skillPanel.Deactivate();
                Time.timeScale = 1f;
            });
            _npsSlot.Button.onClick.AddListener(() => 
            {
                OnSelect.Invoke(_npsSlot.SelectSkill); 
                _skillPanel.Deactivate();
                Time.timeScale = 1f;
            });
            _moveSkill.Button.onClick.AddListener(() => 
            { 
                OnSelect.Invoke(_moveSkill.SelectSkill); 
                _skillPanel.Deactivate();
                Time.timeScale = 1f;
            });
        }

        private void Start()
        {
            OnSelect ??= new();

            _skillPanel.Deactivate();
        }

        private void OnDestroy()
        {
            _attackSkill.Button.onClick.RemoveAllListeners();
            _npsSlot.Button.onClick.RemoveAllListeners();
            _moveSkill.Button.onClick.RemoveAllListeners();
        }

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

            if( lvl > _saveLVL) 
            {
                _skillPanel.Activate();
                Time.timeScale = 0f;

                _saveLVL++;

                ISkillInfo[][] attack = { GradeMap.AttackGrade, GradeMap.GunGrade };

                _attackSkill.SetInfo(attack.RandomElement());
                _npsSlot.SetInfo(GradeMap.NPC);
                _moveSkill.SetInfo(GradeMap.MovementGrade);
            }
        }
    }
}
