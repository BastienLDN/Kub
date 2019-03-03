using UnityEngine;

public class Patroller : MonoBehaviour
{
    #region Public members

    [Header("Patroller parameter")]
    public float  m_speed;
    public float m_patrollerLife;
    public FloatReference m_patrollerDamage;
    public IntReference m_playerLife;

    [Header("Patroller configuration")]
    public float m_distanceFromGround;
    public Transform m_groundDetection;
    public FloatReference m_playerDamage;

    [Header("Feedback/Juice")]
    public GameObject m_bloodSplatter;
    public GameObject m_bloodParticles;
    public GameObject m_deadParticles;
    public GameObject m_playerSplat;
    
    public AudioClip m_clip;

    [Header("Ammo")]
    public GameObject m_ammoLoot;
    public GameObject m_staminaLoot;


    #endregion


    #region System methods

    private void Awake()
    {
        _tr = GetComponent<Transform>();
        _audiosource = GetComponent<AudioSource>();
        _splatHolder = GameObject.FindGameObjectWithTag("SplatHolder").GetComponent<Transform>();
    }

    private void Update()
    {
        _tr.Translate(Vector2.right * m_speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(m_groundDetection.position, Vector2.down, m_distanceFromGround);
        if(groundInfo.collider == false)
        {
            // send patroller to opposite direction
            if(_movingRight == true)
            {
                _tr.eulerAngles = new Vector3(0, -180, 0);
                _movingRight = false;
            }
            else
            {
                _tr.eulerAngles = new Vector3(0, 0, 0);
                _movingRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
     if(collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            m_patrollerLife -= m_playerDamage.Value;
            GameObject obj = Instantiate(m_bloodSplatter, _tr.position, Quaternion.identity);
            obj.transform.parent = _splatHolder.transform;
            GameObject particles = Instantiate(m_bloodParticles, _tr.position, Quaternion.identity);

            if(m_patrollerLife == 0)
            {
                GameObject deadParticle = Instantiate(m_deadParticles, _tr.position, Quaternion.identity);
                GameObject lootStamina = Instantiate(m_staminaLoot, _tr.position, Quaternion.identity);
                GameObject lootAmmo = Instantiate(m_ammoLoot, _tr.position, Quaternion.identity);
                Instantiate(m_staminaLoot, _tr.position, Quaternion.identity);
                Instantiate(m_ammoLoot, _tr.position, Quaternion.identity);
                _audiosource.PlayOneShot(m_clip);
                Destroy(gameObject);
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            m_playerLife.Value -= 1;
        }
    }

    #endregion


    #region Private and protected members

    private Transform _tr;
    private bool _movingRight = true;
    private AudioSource _audiosource;
    private Transform _splatHolder;

    #endregion
}
