using System;
using UnityEngine;

[Serializable]
public class BoolReference
{
    [SerializeField]
    private bool UseConstant = true;
    [SerializeField]
    private bool ConstantValue;

    public BoolVariable Variable;

    public BoolReference() : this(true, true)
    { }

    public BoolReference(bool value) : this(value, true)
    { }

    public BoolReference(bool value, bool useConstant)
    {
        UseConstant = useConstant;
        ConstantValue = value;
    }

    public BoolReference(BoolVariable value)
    {
        UseConstant = false;
        Variable = value;
    }

    public bool Value
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

    public static implicit operator bool(BoolReference reference)
    {
        return reference.Value;
    }
}