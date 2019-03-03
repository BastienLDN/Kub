using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    #region Public members

    [Header("Value stamina/attacks")]
    public FloatReference m_playerStamina;
    public FloatReference m_playerAttack;
    public IntReference m_playerLife;

    [Header("Slider stamina/attacks")]
    public Slider m_staminaSlider;
    public Slider m_attackSlider;
    public Slider m_lifeSlider;


    #endregion


    #region System methods

    private void Update()
    {
        m_staminaSlider.value = m_playerStamina.Value;
        m_attackSlider.value = m_playerAttack.Value;
        m_lifeSlider.value = m_playerLife.Value;
    }

    #endregion
}
