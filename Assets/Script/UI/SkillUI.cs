using System.Linq;
using System.Text;
using DF.Data;
using DF.Extension;
using DF.Interface;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace DF.UI
{
    public class SkillUI : MonoBehaviour
    {
        public Image Icon;
        public TMP_Text Name;
        public TMP_Text Description;
        public Button Button;

        //public PassiveGradePlayer SelectPassive { get; private set; }
        //public GunConfig SelectGun { get; private set; }
        //public NPCConfig SelectNPC { get; private set; }

        public ISkillInfo SelectSkill { get; private set; }

        public void SetInfo(ISkillInfo[] grades)
        {
            var grade = grades.Length == 1 ? grades.First() : grades.RandomElement();
            Icon.sprite = grade.Icon;
            Name.text = grade.Name;
            Description.text = grade.Description;

            SelectSkill = grade;
        }
    }
}
