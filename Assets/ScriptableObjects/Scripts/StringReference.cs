using System;
using UnityEngine;

[Serializable]
public class StringReference
{
    [SerializeField]
    private bool UseConstant = true;
    [SerializeField]
    private string ConstantValue;

    public StringVariable Variable;

    public StringReference() : this("", true)
    { }

    public StringReference(bool useConstant) : this("", useConstant)
    { }

    public StringReference(string value) : this(value, true)
    { }

    public StringReference(string value, bool useConstant)
    {
        UseConstant = useConstant;
        ConstantValue = value;
    }

    public StringReference(StringVariable value)
    {
        UseConstant = false;
        Variable = value;
    }

    public string Value
    {
        get
        {
            return UseConstant ? ConstantValue : Variable.Value;
        }
        set
        {
            if (UseConstant)
            {
                Debug.LogWarning("Cannot set a constant variable");
            }
            else
            {
                Variable.SetValue(value);
            }
        }
    }

    public static implicit operator string(StringReference reference)
    {
        return reference.Value;
    }
}