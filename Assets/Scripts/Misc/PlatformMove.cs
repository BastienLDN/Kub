using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    #region Public members

    [Header("Position")]
    public float m_XMax;
    public float m_XMin;

    [Header("Player move with the platform")]
    public GameObject m_player;
    public GameObject m_playerHolder;

    [Header("Movement Properties")]
    public float m_speed;
    public bool m_isGoingRight;

    #endregion


    #region System methods

    private void Awake()
    {
        _tr = GetComponent<Transform>();
    }

    private void Update()
    {
        Move();
        RevertMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            m_player.transform.parent = gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_player.transform.parent = m_playerHolder.transform;
    }

    #endregion


    #region Main methods

    private void Move()
    {
        if (m_isGoingRight)
        {
            _tr.Translate(Vector3.right * Time.deltaTime * m_speed);
        }
        else
        {
            _tr.Translate(Vector3.left * Time.deltaTime * m_speed);
        }
    }

    private void RevertMove()
    {
        if (m_isGoingRight && _tr.position.x >= m_XMax)
        {
            m_isGoingRight = false;
        }
        else if (m_isGoingRight == false && _tr.position.x <= m_XMin)
        {
            m_isGoingRight = true;
        }
    }

    #endregion


    #region Private and protected members

    private Transform _tr;

    #endregion 
}
