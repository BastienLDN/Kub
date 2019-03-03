using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    #region Public members

    [Header("Refs for animator/state machine")]
    public BoolReference m_isRunning;
    public FloatReference m_axisX;


    [Header("Movement Configuration")]
    public float m_runSpeed;
    public float m_walkSpeed;
    public FloatReference m_staminaValue;

    [Header("Feedbacks")]
    public GameObject m_particlesWalk;
    public GameObject m_particlesRun;

    #endregion


    #region System methods

    private void Awake()
    {
        _tr = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerWalk();
        if((Input.GetButton("Running") || Input.GetKey(KeyCode.LeftShift)) && m_staminaValue.Value > 0)
        {
            m_isRunning.Value = true;
            PlayerRun();
            m_staminaValue.Value -= 0.1f;
        }
        if(!Input.GetButton("Running") || !Input.GetKey(KeyCode.LeftShift))
        {
            m_isRunning.Value = false;
            if(m_staminaValue.Value < 100)
            {
                m_staminaValue.Value += 0.2f;
            }
        }
    }

    #endregion


    #region Main methods 

    private void PlayerWalk()
    {
        m_axisX.Value = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(m_axisX.Value * m_walkSpeed * Time.deltaTime, _rb.velocity.y);
        //GameObject obj = Instantiate(m_particlesWalk, _tr.position, Quaternion.identity);
        //Destroy(obj, 0.1f);

        // character don't turn right when player stop moving.
        if (m_axisX.Value == 0.0f)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        else if (m_axisX.Value > 0)
        {
            _tr.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            Debug.Log("Toto1");
        }
        else
        {
            Debug.Log("toto2");
            _tr.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }

    private void PlayerRun()
    {
        m_axisX.Value = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(m_axisX.Value * m_runSpeed * Time.deltaTime, _rb.velocity.y);

        if (m_axisX.Value == 0.0f)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        else if (m_axisX.Value > 0)
        {
            _tr.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            _tr.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }


    #endregion 


    #region Private and protected members 

    private Transform _tr;
    private Rigidbody2D _rb;

    #endregion
}