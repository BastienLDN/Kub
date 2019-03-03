using UnityEngine.SceneManagement;
using UnityEngine;

public class Help : MonoBehaviour
{
    #region Public members

    public FloatReference m_playerAttacks;
    public FloatReference m_playerStamina;
    public IntReference m_playerLife;

    #endregion


    #region System methods

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_playerAttacks.Value = 100;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_playerStamina.Value = 100;
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_playerLife.Value = 2;
        }

        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            m_playerLife.Value--;
        }
    }


    #endregion


    #region Private and protected members


    #endregion 
}
