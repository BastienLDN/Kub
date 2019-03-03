using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    #region Public members 

    public float m_dashSpeed;
    public float m_startDashTime;

    public GameObject m_particles;
    public BoolReference m_isDashing;
    public FloatReference m_playerStamina;

    #endregion


    #region System methods 

    private void Awake()
    {
        _tr = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
        _dashTime = m_startDashTime;
    }

    private void Update()
    {
        if(m_playerStamina.Value <= 0)
        {
            m_isDashing.Value = false;
            return;
        }
        else if (_dashTime <= 0)
        {
            _dashTime = m_startDashTime;
            _rb.velocity = new Vector2(0.0f, _rb.velocity.y);
            m_isDashing.Value = true;
            Debug.Log("test_1");
        }
        else if (Input.GetButtonDown("DashingLeft"))
        {
            GameObject obj = Instantiate(m_particles, _tr.position, Quaternion.identity);
            Destroy(obj, 0.4f);
            _dashTime -= Time.deltaTime;
            _rb.AddForce(Vector2.left * m_dashSpeed);
            m_playerStamina.Value -= 25;
        }
        else if (Input.GetButtonDown("DashingRight"))
        {
            GameObject obj = Instantiate(m_particles, _tr.position, Quaternion.identity);
            Destroy(obj, 0.4f);
            _dashTime -= Time.deltaTime;
            _rb.AddForce(Vector2.right * m_dashSpeed);
            m_playerStamina.Value -= 25;
        }
    }

    #endregion


    #region Private and protected members 

    private Transform _tr;
    private Rigidbody2D _rb;
    private float _dashTime;

    #endregion 
}
