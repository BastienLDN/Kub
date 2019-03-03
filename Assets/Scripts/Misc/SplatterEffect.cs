using UnityEngine;

public class SplatterEffect : MonoBehaviour
{
    public GameObject m_bulletOrangeEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBullet"))
        {
            GameObject obj = Instantiate(m_bulletOrangeEffect, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
