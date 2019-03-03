using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTree : MonoBehaviour
{
    #region Public members

    public enum E_AttackSkills
    {
        INVALID = -1, 

        STATE_SIMPLESHOT, 
        STATE_SHOTGUN,
        STATE_GROUNDSMASH, 
        STATE_SPECIAL,

        MAX
    }

    [Header("Player mode")]
    public BoolReference m_isAgilityMode; // if false, then gameObject is active
    public E_AttackSkills m_currentAttackState;

    [Header("Progression Check")]
    public BoolReference m_lvl2Finished;
    public BoolReference m_lvl3Finished;
    public BoolReference m_lvl5Finished;
    public BoolReference m_lvl6Finished;
    public BoolReference m_lvl7Finished;

    #endregion


    #region System methods


    #endregion 
}
