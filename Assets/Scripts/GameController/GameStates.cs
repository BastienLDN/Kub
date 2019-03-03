using UnityEngine;

public class GameStates : MonoBehaviour
{
    #region Public members 

    public enum e_gameStates
    {
        INVALID = -1, 

        STATE_RUNNING, 
        STATE_PAUSED,

        MAX
    }

    public static e_gameStates m_currentGameState;
    public KeyCode m_pauseGameKey;
    public BoolReference m_isPaused;

    #endregion


    #region System methods

    private void Awake()
    {
        m_currentGameState = e_gameStates.STATE_RUNNING;
    }


    private void Update()
    {
        switch(m_currentGameState)
        {
            case e_gameStates.STATE_RUNNING:
                if (Input.GetKeyDown(m_pauseGameKey))
                {
                    m_currentGameState = e_gameStates.STATE_PAUSED;
                    m_isPaused.Value = true;
                }
                break;

            case e_gameStates.STATE_PAUSED:
                if (m_isPaused.Value = true && Input.GetKeyDown(m_pauseGameKey))
                {
                    m_currentGameState = e_gameStates.STATE_RUNNING;
                    m_isPaused.Value = false;
                }
                break;
        }
    }

    #endregion
}
