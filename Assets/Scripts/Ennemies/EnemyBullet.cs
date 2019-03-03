using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    #region Public members

    public IntReference m_playerLife;
    public float m_speed;
    public GameObject m_playerSplat;
    public GameObject m_bulletDestroyed;

    #endregion


    #region System methods

    private void Awake()
    {
        _tr = GetComponent<Transform>();
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        m_target = new Vector2(m_player.position.x, m_player.position.y);
        _splatHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        _tr.position = Vector2.MoveTowards(_tr.position, m_target, m_speed * Time.deltaTime);

        if (_tr.position.x == m_target.x && _tr.position.y == m_target.y)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            m_playerLife.Value -=1;
            DestroyProjectile();
        }
    }

    #endregion


    #region Main methods

    private void DestroyProjectile()
    {
        Destroy(gameObject);
        Instantiate(m_bulletDestroyed, _tr.position, Quaternion.identity);
    }

    #endregion 


    #region Private and protected memberss

    private Transform _tr;
    private Transform m_player;
    private Vector2 m_target;
    private Transform _splatHolder;

    #endregion 
}
