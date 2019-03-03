using UnityEngine;

public class Ammo : MonoBehaviour
{
    #region Public members

    public FloatReference m_attackValue;
    public float m_bonusValue;

    #endregion


    #region System methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(m_attackValue.Value < 100)
            {
                m_attackValue.Value += m_bonusValue;
            }
            Destroy(gameObject);
        }
    }

    #endregion 
}
