using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    #region Public members

    public float m_shakeDuration;
    public float m_shakeAmplitude;
    public float m_shakeFrequency = 2.0f;
    public CinemachineVirtualCamera m_virtualCam;

    #endregion


    #region System methods

    private void Start()
    {
        if (m_virtualCam != null)
            _virtualCameraNoise = m_virtualCam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("DashingLeft") || Input.GetButtonDown("DashingRight") || Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("vlambeer");
            _shakeElapsedTime = m_shakeDuration;
        }

        if (m_virtualCam != null || _virtualCameraNoise != null)
        {
            if (_shakeElapsedTime > 0)
            {
                _virtualCameraNoise.m_AmplitudeGain = m_shakeAmplitude;
                _virtualCameraNoise.m_FrequencyGain = m_shakeFrequency;

                _shakeElapsedTime -= Time.deltaTime;
            }
            else
            {
                _virtualCameraNoise.m_AmplitudeGain = 0.0f;
                _shakeElapsedTime = 0.0f;
            }
        }
    }

    #endregion


    #region Private and protected members 

    private float _shakeElapsedTime = 0.0f;
    private CinemachineBasicMultiChannelPerlin _virtualCameraNoise;

    #endregion 
}
