using UnityEngine;

public class rotator : MonoBehaviour
{
    public Vector3 m_offset;

    private void Awake()
    {
        _tr = GetComponent<Transform>();
    }

    private void Update()
    {
        _tr.Rotate(m_offset * Time.deltaTime);
    }

    private Transform _tr;
}
