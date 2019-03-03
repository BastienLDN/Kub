using UnityEngine;

[CreateAssetMenu(menuName ="Variables/Level")]
public class Level : ScriptableObject
{
    public string m_lvlName;
    public int m_lvlNumber;
    public bool m_isComplete;
    public int m_times;
    public BoolReference m_reward; // can SkillName;
}
