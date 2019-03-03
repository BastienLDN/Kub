﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveSound : MonoBehaviour
{
    #region Public members 

    public float m_backgroundIntensity;
    public Material m_backgroundMaterial;
    public Color m_minColor;
    public Color m_maxColor;

    public float m_rmsValue; // avg power input of the sound;
    public float m_dbValue;
    public float m_pitchValue;

    public float m_maxVisualScale = 25.0f;
    public float m_visualModifier = 50.0f;
    public float m_smoothSpeed = 10.0f;
    public float m_keepPercentage = 0.5f;

    #endregion


    #region System methods

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        _samples = new float[SAMPLE_SIZE];
        _spectrum = new float[SAMPLE_SIZE];
        _sampleRate = AudioSettings.outputSampleRate;
        //SpawnLine();
        //SpawnCircle();
    }

    private void Update()
    {
        AnalyzeSound();
        //UpdateVisual();
        UpdateBackground();
    }

    #endregion


    #region Main methods 

    private void AnalyzeSound()
    {
        _source.GetOutputData(_samples, 0);
        //GetTheRMS
        int i = 0;
        float sum = 0;
        for (; i < SAMPLE_SIZE; i++)
        {
            sum = _samples[i] * _samples[i];
        }
        m_rmsValue = Mathf.Sqrt(sum / SAMPLE_SIZE);

        // Get the db value 
        m_dbValue = 20 * Mathf.Log10(m_rmsValue / 0.1f);

        // GetSoundSpectrum / Visualization
        _source.GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
    }

    private void SpawnLine()
    {
        _visualScale = new float[_amountVisual];
        _visualList = new Transform[_amountVisual];

        for (int i = 0; i < _amountVisual; i++)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;
            _visualList[i] = obj.transform;
            _visualList[i].position = Vector3.right * i;
        }
    }
    private void SpawnCircle()
    {
        _visualScale = new float[_amountVisual];

        _visualList = new Transform[_amountVisual];
        Vector3 center = Vector3.zero;
        float radius = 10.0f;

        for (int i = 0; i < _amountVisual; i++)
        {
            float ang = 1 * 1.0f / _amountVisual;
            ang = ang * Mathf.PI * 2;

            float x = center.x + Mathf.Cos(ang) * radius;
            float y = center.y + Mathf.Cos(ang) * radius;

            Vector3 pos = center + new Vector3(x, y, 0);
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;
            obj.transform.position = pos;
            obj.transform.rotation = Quaternion.LookRotation(Vector3.forward, pos);
            _visualList[i] = obj.transform;
        }
    }

    private void UpdateVisual()
    {
        int visualIndex = 0;
        int spectrumIndex = 0;
        int averageSize = (int)(SAMPLE_SIZE * m_keepPercentage) / _amountVisual;

        while (visualIndex < _amountVisual)
        {
            int j = 0;
            float sum = 0;

            while (j < averageSize)
            {
                sum += _spectrum[spectrumIndex];
                spectrumIndex++;
                j++;
            }

            float scaleY = sum / averageSize * m_visualModifier;
            _visualScale[visualIndex] -= Time.deltaTime * m_smoothSpeed;
            if (_visualScale[visualIndex] < scaleY)
            {
                _visualScale[visualIndex] = scaleY;
            }

            if (_visualScale[visualIndex] > m_maxVisualScale)
            {
                _visualScale[visualIndex] = m_maxVisualScale; // can't go further than this 
            }

            _visualList[visualIndex].localScale = Vector3.one + Vector3.up * _visualScale[visualIndex];
            visualIndex++;
        }
    }
    private void UpdateBackground()
    {
        m_backgroundIntensity -= Time.deltaTime * m_smoothSpeed;
        if(m_backgroundIntensity < m_dbValue / 40)
        {
            m_backgroundIntensity = m_dbValue / 40;
        }
        m_backgroundMaterial.color = Color.Lerp(m_maxColor, m_minColor, -m_backgroundIntensity);
    }

    #endregion


    #region Private and protected members

    private const int SAMPLE_SIZE = 1024;
    private AudioSource _source;
    private float[] _samples;
    private float[] _spectrum;
    private float _sampleRate;

    // Visualization with cubes. 
    private Transform[] _visualList;
    private float[] _visualScale;
    private int _amountVisual = 100; // how many cubes. 

    #endregion
}
