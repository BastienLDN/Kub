using UnityEngine;

public class Blocks : MonoBehaviour
{
    #region Public members

    [Header("Blocks Configuration")]
    public float m_blocksSpeed;
    public float m_blocksLife;
    public FloatReference m_playerDamage;
    public float m_stoppingDistance; // distance where the blocks stop from the player position
    public float m_retreatDistance; // back away from the player

    public Transform m_player;

    [Header("Shooting")]
    public float m_startTimeBtwShots;
    public GameObject m_projectile;
    public bool m_isPlayerDetected;

    [Header("Feedback/Juice")]
    public GameObject m_bloodSplatter;
    public GameObject m_bloodParticles;
    public GameObject m_deadParticles;

    [Header("Ammo")]
    public GameObject m_ammoLoot;
    public GameObject m_staminaLoot;

    #endregion


    #region System methods

    private void Awake()
    {
        _splatHolder = GameObject.FindGameObjectWithTag("SplatHolder").GetComponent<Transform>();
        _tr = GetComponent<Transform>();
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        m_timeBtwShots = m_startTimeBtwShots;
    }

    private void Update()
    {
        if(m_isPlayerDetected == true)
        {
            // check how far our player is from the ennemy
            if (Vector2.Distance(_tr.position, m_player.position) > m_stoppingDistance)
            {
                // move to the ennemy
                _tr.position = Vector2.MoveTowards(_tr.position, m_player.position, m_blocksSpeed * Time.deltaTime);
            }
            // stop moving
            else if (Vector2.Distance(_tr.position, m_player.position) < m_stoppingDistance && Vector2.Distance(_tr.position, m_player.position) > m_retreatDistance)
            {
                _tr.position = this._tr.position;
            }
            //back away
            else if (Vector2.Distance(_tr.position, m_player.position) < m_retreatDistance)
            {
                _tr.position = Vector2.MoveTowards(_tr.position, m_player.position, -m_blocksSpeed * Time.deltaTime);
            }


            if (m_timeBtwShots <= 0)
            {
                Instantiate(m_projectile, _tr.position, Quaternion.identity);
                m_timeBtwShots = m_startTimeBtwShots;
            }
            else
            {
                m_timeBtwShots -= Time.deltaTime;
            }
        }
        else
        {
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            m_blocksLife -= m_playerDamage.Value;
            GameObject obj = Instantiate(m_bloodSplatter, _tr.position, Quaternion.identity);
            obj.transform.parent = _splatHolder.transform;
            GameObject particles = Instantiate(m_bloodParticles, _tr.position, Quaternion.identity);

            if (m_blocksLife == 0)
            {
                GameObject deadParticle = Instantiate(m_deadParticles, _tr.position, Quaternion.identity);
                GameObject lootStamina = Instantiate(m_staminaLoot, _tr.position, Quaternion.identity);
                GameObject lootAmmo = Instantiate(m_ammoLoot, _tr.position, Quaternion.identity);
                Instantiate(m_staminaLoot, _tr.position, Quaternion.identity);
                Instantiate(m_ammoLoot, _tr.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            m_isPlayerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            m_isPlayerDetected = false;
        }
    }

    #endregion


    #region Private and protected members

    private Transform _splatHolder;
    private Transform _tr;
    private float m_timeBtwShots;

    #endregion
}
