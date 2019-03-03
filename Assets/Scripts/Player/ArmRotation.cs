using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    #region Public members
    
    [Header("Aim configuration")]
    public Transform m_player;
    public float m_radius;
    public float m_offset;

    [Header("Bullet configuration")]
    public GameObject m_projectile;

    [Header("Player Properties")]
    public FloatReference m_playerAttack;

    #endregion


    #region System methods

    private void Awake()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _transform = GetComponent<Transform>();
        _pivot = m_player.GetComponent<Transform>();
        _transform.parent = _pivot;
        _transform.position = Vector3.up * m_radius;
    }

    private void Update()
    {
        Vector3 difference = _camera.WorldToScreenPoint(m_player.position);
        difference = Input.mousePosition - difference;
        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        _pivot.position = m_player.position;
        _pivot.rotation = Quaternion.AngleAxis(angle - m_offset, Vector3.forward);
        PlayerShoot();
    }

    #endregion


    #region Main methods

    private void PlayerShoot()
    {
        if (Input.GetButtonDown("Fire1") && m_playerAttack.Value > 0)
        {
            GameObject obj = Instantiate(m_projectile, _transform.position, m_player.localRotation);
            obj.GetComponent<BulletBehaviour>().m_player = m_player;
            obj.GetComponent<BulletBehaviour>().m_aim = _transform.parent;
            m_playerAttack.Value -= 2;
        }
    }

    #endregion


    #region Private and protected members 

    private Camera _camera;
    private Transform _transform; // Transform of my aim arrow. 
    private Transform _pivot; // The player center

    #endregion 
}
