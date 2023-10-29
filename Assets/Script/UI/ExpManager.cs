using System.Text;
using DF.Data;
using DF.Extension;
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

        public UnityEvent<PassiveGradePlayer> OnSelectPassiveSkill;
        public UnityEvent<NPCConfig> OnSelectNPC;

        private float _saveValue;
        private float _saveLVL;
        private float _newValue;
        private IStop _timer;

        private void Awake()
        {
            _attackSkill.Button.onClick.AddListener(() => { OnSelectPassiveSkill.Invoke(_attackSkill.SelectPassive); _skillPanel.Deactivate(); });
            _npsSlot.Button.onClick.AddListener(() => { OnSelectNPC.Invoke(_npsSlot.SelectNPC); _skillPanel.Deactivate(); });
            _moveSkill.Button.onClick.AddListener(() => { OnSelectPassiveSkill.Invoke(_moveSkill.SelectPassive); _skillPanel.Deactivate(); });
        }

        private void Start()
        {
            OnSelectPassiveSkill ??= new();
            OnSelectNPC ??= new();

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

                _saveLVL++;

                _attackSkill.RandomSetPassive(GradeMap.AttackGrade);
                _npsSlot.RandomSetNPC(GradeMap.NPC);
                _moveSkill.RandomSetPassive(GradeMap.MovementGrade);
            }
        }
    }
}
