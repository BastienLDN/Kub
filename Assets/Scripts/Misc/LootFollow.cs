using UnityEngine;

public class LootFollow : MonoBehaviour
{
    #region Public members

    public float m_minModifier = 7;
    public float m_maxModifier = 11;

    #endregion


    #region System methods

    private void Awake()
    {
        _tr = GetComponent<Transform>();
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (_isFollowing)
        {
            _tr.position = Vector2.SmoothDamp(_tr.position, _target.position, ref _velocity, Time.deltaTime * Random.Range(m_minModifier, m_maxModifier));
        }
    }

    #endregion


    #region Main methods

    public void StartFollowing()
    {
        _isFollowing = true;
    }

    #endregion


    #region Private and protected members 

    private Transform _target;
    private Transform _tr;
    private Vector2 _velocity = Vector2.zero;
    private bool _isFollowing = false;

    #endregion 
}