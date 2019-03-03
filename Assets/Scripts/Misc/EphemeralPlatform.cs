using UnityEngine;

public class EphemeralPlatform : MonoBehaviour
{
    #region Public members

    public float m_timeBeforeDestroy;
    public GameObject m_platformParticles;

    #endregion


    #region System methods

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _Time += Time.deltaTime;
            if (_Time >= m_timeBeforeDestroy)
            {
                Instantiate(m_platformParticles, transform.position, Quaternion.identity);
            }
            Destroy(gameObject, m_timeBeforeDestroy);
        }
    }

    #endregion


    #region Private and protected members

    private float _Time = 0;

    #endregion 
}
