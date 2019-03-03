using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    #region Public members

    public GameObject m_bulletSplatterEffect;
    public GameObject m_enemySplatterEffect;
    private Transform _splatterParent;
    public GameObject m_bulletDestroyParticle;

    #endregion


    #region System methods

    private void Awake()
    {
        _splatterParent = GameObject.FindGameObjectWithTag("SplatHolder").GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            GameObject obj = Instantiate(m_bulletSplatterEffect, collision.transform.position, Quaternion.identity);
            obj.transform.parent = _splatterParent.transform;
            Destroy(collision.gameObject);
            GameObject particles = Instantiate(m_bulletDestroyParticle, collision.transform.position, Quaternion.identity);
        }
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            GameObject obj2 = Instantiate(m_enemySplatterEffect, collision.transform.position, Quaternion.identity);
            obj2.transform.parent = _splatterParent.transform;
            Destroy(collision.gameObject);
        }
    }

    #endregion 
}
