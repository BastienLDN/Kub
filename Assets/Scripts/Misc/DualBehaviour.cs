using UnityEngine;

public class DualBehaviour : MonoBehaviour
{
    #region System methods

    protected virtual void Awake()
    {
        /*
#if UNITY_EDITOR

       if (!GameObject.FindGameObjectWithTag("Manager"))
        {
            Instantiate(Resources.Load("Prefabs/Managers/Manager"));
        } 

#endif
*/
    }

    protected virtual void Update()
    {
        if (GameStates.m_currentGameState == GameStates.e_gameStates.STATE_PAUSED)
        {
            return;
        }
    }

    #endregion
}
