using UnityEngine;

public class AgilityTree : MonoBehaviour
{
    #region Public members

    public enum E_AgilitySkills
    {
        INVALID = -1, 

        STATE_DASH, 
        STATE_HOOK, 
        STATE_TELEPORTATION, 

        MAX
    }

    [Header("Player mode")]
    public BoolReference m_isAgilityMode; // if false, then game object is inactive;
    public E_AgilitySkills m_currentAgilityState;


    #endregion


    #region System methods


    #endregion 
}
