using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    #region Public members 

    [Header("Reference")]
    public BoolReference m_isGrounded;

    [Header("Jump Configuration")]
    public Transform m_feetPosition;
    public float m_checkRadius;
    public LayerMask m_whatIsGround;
    public float m_jumpVelocity;
    public float m_jumpTime;
    public int m_jumpCounter;

    #endregion


    #region System methods

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _tr = GetComponent<Transform>();
        m_jumpCounter = 2;
        m_jumpCounter = _jumpLeft;

    }

    private void Update()
    {
        m_isGrounded.Value = Physics2D.OverlapCircle(m_feetPosition.position, m_checkRadius, m_whatIsGround);
        if(m_isGrounded.Value == true)
        {
            _jumpLeft = m_jumpCounter;
        }

        if (m_isGrounded.Value == true && Input.GetButtonDown("Jumping") || _jumpLeft > 0)
        {
            _isJumping = true;
            _jumpTimeCounter = m_jumpTime;
            _rb.velocity = Vector2.up * m_jumpVelocity;
            _jumpLeft--;
        }

        if(Input.GetButton("Jumping") && _isJumping == true)
        {
            if(_jumpTimeCounter > 0)
            {
                _rb.velocity = Vector2.up * m_jumpVelocity;
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                _isJumping = false;
            }
        }

        if(Input.GetButtonUp("Jumping"))
        {
            _isJumping = false;
        }
    }

    #endregion


    #region Private and protected members 

    private Rigidbody2D _rb;
    private Transform _tr;
    private bool _isJumping;
    private float _jumpTimeCounter;
    private int _jumpLeft;

    #endregion 
}
