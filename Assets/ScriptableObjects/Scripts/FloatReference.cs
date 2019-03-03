using System;
using UnityEngine;

[Serializable]
public class FloatReference
{
    [SerializeField]
    private bool UseConstant = true;
    [SerializeField]
    private float ConstantValue;

    public FloatVariable Variable;

    public FloatReference() : this(0f, true)
    { }

    public FloatReference(bool useConstant) : this(0f, useConstant)
    { }

    public FloatReference(float value) : this(value, true)
    { }

    public FloatReference(float value, bool useConstant)
    {
        UseConstant = useConstant;
        ConstantValue = value;
    }

    public FloatReference(FloatVariable value)
    {
        UseConstant = false;
        Variable = value;
    }

    public float Value
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

    public static implicit operator float(FloatReference reference)
    {
        return reference.Value;
    }
}