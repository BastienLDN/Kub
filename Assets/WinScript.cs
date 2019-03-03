using UnityEngine;
using TMPro;

public class WinScript : MonoBehaviour
{
    #region Public members

    public GameObject m_text;
    public TextMeshProUGUI m_textTimer;
    public FloatReference m_timer;

    #endregion


    #region System methods

    private void Awake()
    {
        m_text.SetActive(false);
        m_textTimer.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(_win == false)
        {
            m_timer.Value =(int) Time.timeSinceLevelLoad;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _win = true;
            m_text.SetActive(true);
            m_textTimer.text = "Your time : " + m_timer.Value + "seconds";
            m_textTimer.gameObject.SetActive(true);
        }
    }

    #endregion


    #region Private and protected members 

    private bool _win;

    #endregion 
}