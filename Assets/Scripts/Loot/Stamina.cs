using UnityEngine;

public class Stamina : MonoBehaviour
{
    #region Public members

    public FloatReference m_staminaValue;
    public float m_bonusValue;

    #endregion


    #region System methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(m_staminaValue.Value < 100)
            {
                m_staminaValue.Value += m_bonusValue;
            }
            Destroy(gameObject);
        }
    }

    #endregion
}
