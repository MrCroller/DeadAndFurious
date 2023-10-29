using UnityEngine;

namespace DF.Data
{
    [CreateAssetMenu(fileName = nameof(DialogConfig), menuName = "DF/Configs/Dialog")]
    public class DialogConfig : ScriptableObject
    {
        [SerializeField] private string[] _dialog;
        public string[] Texts => _dialog;
    }
}
