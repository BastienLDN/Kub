using UnityEngine;

public class ColorSwap : MonoBehaviour
{
    #region Public members 

    [Header("Player Settings")]
    public GameObject m_playerSkin;
    public GameObject m_playerEye_Left;
    public GameObject m_playerEye_Right;
    public GameObject m_playerMouth;
    public GameObject m_playerMouth_Smile;

    [Header("Prologue")]
    public BoolReference m_canSwapColor;

    [Header("Attack mode")]
    public Material m_attackSkinColor;
    public Material m_attackMiscColor;

    [Header("Agility mode")]
    public Material m_agilitySkinColor;
    public Material m_agilityMiscColor;
    public BoolReference m_agilityMode;

    [Header("Feedbacks")]
    public BoolReference m_isSwappingColor;


    #endregion


    #region System methods

    private void Awake()
    {
        m_canSwapColor.Value = true;
        m_agilityMode.Value = true;
    }

    private void Update()
    {
       if(m_canSwapColor.Value == true)
        {
            if(Input.GetButtonDown("ColorSwap") || Input.GetKeyDown(KeyCode.Tab))
            {
                if(m_agilityMode.Value == true)
                {
                    m_playerSkin.GetComponent<Renderer>().material = m_agilitySkinColor;
                    m_playerEye_Left.GetComponent<Renderer>().material = m_agilityMiscColor;
                    m_playerEye_Right.GetComponent<Renderer>().material = m_agilityMiscColor;
                    m_playerMouth.GetComponent<Renderer>().material = m_agilityMiscColor;
                    m_playerMouth_Smile.GetComponent<Renderer>().material = m_agilityMiscColor;
                }
                else if(m_agilityMode.Value == false)
                {
                    m_playerSkin.GetComponent<Renderer>().material = m_attackSkinColor;
                    m_playerEye_Left.GetComponent<Renderer>().material = m_attackMiscColor;
                    m_playerEye_Right.GetComponent<Renderer>().material = m_attackMiscColor;
                    m_playerMouth.GetComponent<Renderer>().material = m_attackMiscColor;
                    m_playerMouth_Smile.GetComponent<Renderer>().material = m_attackMiscColor;
                }

            }
        }
    }


    #endregion
}
