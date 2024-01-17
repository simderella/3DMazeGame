using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetValure : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider slider;

    private void Awake()
    {
        slider.onValueChanged.AddListener(SetLevel);
    }

    public void SetLevel(float sliderVal)
    {
        mixer.SetFloat("BackGroundVol", Mathf.Log10(sliderVal) * 20);
    }
}
