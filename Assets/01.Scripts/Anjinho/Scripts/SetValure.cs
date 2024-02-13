using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetValure : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider effectSlider;

    private void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMaster);
        bgmSlider.onValueChanged.AddListener(SetBgm);
        effectSlider.onValueChanged.AddListener(SetEffect);
    }

    public void SetMaster(float slider)
    {
        mixer.SetFloat("Master", Mathf.Log10(slider) * 20);
       // SoundManager를 통해 배경음과 효과음 볼륨 설정
    }

    public void SetBgm(float slider)
    {
        mixer.SetFloat("BGM", Mathf.Log10(slider) * 20);
        // SoundManager를 통해 배경음과 효과음 볼륨 설정
    }

    public void SetEffect(float slider)
    {
        mixer.SetFloat("Effect", Mathf.Log10(slider) * 20);
        // SoundManager를 통해 배경음과 효과음 볼륨 설정
    }
}
