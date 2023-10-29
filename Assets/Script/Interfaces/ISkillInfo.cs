using UnityEngine;

namespace DF.Interface
{
    public interface ISkillInfo
    {
        Sprite Icon { get; }
        string Name { get; }
        string Description { get; }
    }
}
