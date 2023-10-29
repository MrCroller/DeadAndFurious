using System.Linq;
using System.Text;
using DF.Data;
using DF.Extension;
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

        public PassiveGradePlayer SelectPassive { get; private set; }
        public NPCConfig SelectNPC { get; private set; }

        public void RandomSetPassive(PassiveGradePlayer[] grades)
        {
            var grade = grades.Length == 1 ? grades.First() : grades.RandomElement();
            Icon.sprite = grade.Icon;
            Name.text = grade.Name;

            StringBuilder description = new();

            if (grade.Speed > 0) description.Append($"Скорость +{grade.Speed}\n");
            if (grade.MovementSmoothing > 0) description.Append($"Резвость +{grade.MovementSmoothing}\n");
            if (grade.Damage > 0) description.Append($"Урон +{grade.Damage}\n");
            if (grade.SpeedAtackDelay > 0) description.Append($"Скорость атаки +{grade.SpeedAtackDelay}\n");

            Description.text = description.ToString();

            SelectPassive = grade;
        }

        public void RandomSetNPC(NPCConfig[] grades)
        {
            var npc = grades.Length == 1 ? grades.First() : grades.RandomElement();
            Name.text = npc.Name;
            Icon.sprite = npc.Icon;
            Description.text = npc.Description;

            SelectNPC = npc;
        }

    }
}
