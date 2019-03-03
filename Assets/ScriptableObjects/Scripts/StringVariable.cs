using UnityEngine;

[CreateAssetMenu(menuName = "Variables/String Variable")]
public class StringVariable : ScriptableObject
{
    public string Value;

    public void SetValue(string value)
    {
        Value = value;
    }

    public void SetValue(StringVariable value)
    {
        Value = value.Value;
    }
}
