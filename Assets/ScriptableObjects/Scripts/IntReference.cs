using System;
using UnityEngine;

[Serializable]
public class IntReference
{
    [SerializeField]
    private bool UseConstant = true;
    [SerializeField]
    private int ConstantValue;

    public IntVariable Variable;

    public IntReference() : this(0, true)
    { }

    public IntReference(bool useConstant) : this(0, useConstant)
    { }

    public IntReference(int value) : this(value, true)
    { }

    public IntReference(int value, bool useConstant)
    {
        UseConstant = useConstant;
        ConstantValue = value;
    }

    public IntReference(IntVariable value)
    {
        UseConstant = false;
        Variable = value;
    }

    public int Value
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

    public static implicit operator int(IntReference reference)
    {
        return reference.Value;
    }
}