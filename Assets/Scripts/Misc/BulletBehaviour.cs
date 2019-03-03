using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    #region Public members

    public float m_speed;
    public float m_lifeTime;
    public Transform m_aim;
    public Transform m_player;
    //public GameObject m_destroyEffect;

    #endregion 

    private void Start()
    {
        _tr = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
        _direction = (m_aim.position - _tr.position).normalized;
        DestroyProjectile();
        _rb.AddForce(m_aim.up * m_speed);
    }


    private void DestroyProjectile()
    {
        //GameObject obj = Instantiate(m_destroyEffect, _tr.position, Quaternion.identity);
        Destroy(gameObject, m_lifeTime);
    }

    #region Private and protected members

    private Transform _tr;
    private Rigidbody2D _rb;
    private Vector3 _direction;

    #endregion 
}
