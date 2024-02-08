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
       // SoundManager를 통해 배경음과 효과음 볼륨 설정
        //SoundManager.Instance.SetMusicVolume(sliderVal);
    }
}
