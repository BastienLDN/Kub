using UnityEngine;

public class StateMachine : DualBehaviour
{
    #region Public members 

    public enum E_PlayerStates
    {
        INVALID = -1, 

        STATE_IDLE,
        STATE_WALK,
        STATE_RUN,
        STATE_JUMP,
        STATE_COLORSWAP,

        MAX
    }
    [Header("Current State")]
    public E_PlayerStates m_currentPlayerState;

    [Header("Reference")]
    public BoolReference m_isRunning;
    public BoolReference m_isGrounded;
    public BoolReference m_AgilityMode;
    public FloatReference m_xInput;
    public IntReference m_playerLife;
    public FloatReference m_playerStamina;
    public FloatReference m_playerAttacks;
    public FloatReference m_timer;

    #endregion


    #region System methods

    protected override void Awake()
    {
        base.Awake();
        m_currentPlayerState = E_PlayerStates.STATE_IDLE;
        m_isGrounded.Value = true;
        m_isRunning.Value = false;
        m_playerLife.Value = 2;
        m_playerStamina.Value = 100;
        m_playerAttacks.Value = 100;
        m_timer.Value = 0;
    }

    protected override void Update()
    {
        base.Update();

        switch(m_currentPlayerState)
        {
            case E_PlayerStates.STATE_IDLE:
                if(m_xInput.Value != 0)
                {
                    m_currentPlayerState = E_PlayerStates.STATE_WALK;
                }
                if(Input.GetButtonDown("Jumping") || Input.GetKeyDown(KeyCode.Space) ||m_isGrounded.Value == false)
                {
                    m_currentPlayerState = E_PlayerStates.STATE_JUMP;
                }
                if (Input.GetButtonDown("ColorSwap") || Input.GetKeyDown(KeyCode.Tab))
                {

                    m_currentPlayerState = E_PlayerStates.STATE_COLORSWAP;
                    if (m_AgilityMode.Value == true)
                    {
                        m_AgilityMode.Value = false;
                    }
                    else
                    {
                        m_AgilityMode.Value = true;
                    }
                }
                break;

            case E_PlayerStates.STATE_WALK:
                if(m_xInput.Value == 0)
                {
                    m_currentPlayerState = E_PlayerStates.STATE_IDLE;
                }
                if(Input.GetButton("Running") || Input.GetKey(KeyCode.LeftShift))
                {
                    m_currentPlayerState = E_PlayerStates.STATE_RUN;
                }
                if(Input.GetButtonDown("Jumping") || Input.GetKeyDown(KeyCode.Space))
                {
                    m_currentPlayerState = E_PlayerStates.STATE_JUMP;
                }
                if (Input.GetButtonDown("ColorSwap") || Input.GetKeyDown(KeyCode.Tab))
                {
                    m_currentPlayerState = E_PlayerStates.STATE_COLORSWAP;
                    if (m_AgilityMode.Value == true)
                    {
                        m_AgilityMode.Value = false;
                    }
                    else
                    {
                        m_AgilityMode.Value = true;
                    }
                }
                break;

            case E_PlayerStates.STATE_RUN:
                if(Input.GetButtonUp("Running") || Input.GetKeyUp(KeyCode.LeftShift))
                {
                    m_currentPlayerState = E_PlayerStates.STATE_WALK;
                }
                if (Input.GetButtonDown("ColorSwap") || Input.GetKeyDown(KeyCode.Tab))
                {
                    m_currentPlayerState = E_PlayerStates.STATE_COLORSWAP;
                    if (m_AgilityMode.Value == true)
                    {
                        m_AgilityMode.Value = false;
                    }
                    else
                    {
                        m_AgilityMode.Value = true;
                    }
                }
                break;

            case E_PlayerStates.STATE_JUMP:
                if(m_isGrounded.Value == true)
                {
                    m_currentPlayerState = E_PlayerStates.STATE_IDLE;
                }
                if (Input.GetButtonDown("ColorSwap") || Input.GetKeyDown(KeyCode.Tab))
                {
                    m_currentPlayerState = E_PlayerStates.STATE_COLORSWAP;
                    if (m_AgilityMode.Value == true)
                    {
                        m_AgilityMode.Value = false;
                    }
                    else
                    {
                        m_AgilityMode.Value = true;
                    }
                }
                break;

            case E_PlayerStates.STATE_COLORSWAP:
                if(m_isGrounded.Value == false || Input.GetButtonDown("Jumping") || Input.GetKeyDown(KeyCode.Space)) 
                {
                    m_currentPlayerState = E_PlayerStates.STATE_JUMP;
                }
                if(m_xInput.Value == 0)
                {
                    m_currentPlayerState = E_PlayerStates.STATE_IDLE;
                }
                if(m_xInput.Value != 0)
                {
                    m_currentPlayerState = E_PlayerStates.STATE_WALK;
                }
                if(Input.GetButton("Running") || Input.GetKey(KeyCode.LeftShift))
                {
                    m_currentPlayerState = E_PlayerStates.STATE_RUN;
                }
                break;
        }

        if(m_playerLife.Value == 0)
        {
            Destroy(gameObject);
        }
    }

    #endregion


    #region Tools And debugging

    /*
    private void OnGUI()
    {
        GUILayout.Button("current player state " + m_currentPlayerState.ToString());
        GUILayout.Button("isGrounded : " + m_isGrounded.Value.ToString());
        GUILayout.Button("Agility mode : " + m_AgilityMode.Value.ToString());
        GUILayout.Button("isRunning : " + m_isRunning.Value.ToString());
    }*/

    #endregion
}