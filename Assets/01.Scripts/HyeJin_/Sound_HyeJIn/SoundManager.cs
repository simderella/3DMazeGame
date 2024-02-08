using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;


    // 사운드 정보를 담는 클래스
    [System.Serializable]
    public class Sound
    {
        public string name; // 사운드 이름
        public AudioClip clip; // 오디오 클립
    }

    // 배경 음악을 담을 배열
    public Sound[] musicSounds;
    // 효과음을 담을 배열
    public Sound[] sfxSounds;

    // 배경 음악을 재생할 AudioSource
    public AudioSource musicSource;
    // 효과음을 재생할 AudioSource
    public AudioSource sfxSource;

    private bool isFootstepPlaying = false; // 걷는 소리가 현재 재생 중인지 여부
    private bool isRunningPlaying = false;


    private void Awake()
    {
        // 사운드 매니저 인스턴스 설정
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound music in musicSounds)
        {
            // 배경 음악 초기화
            if (music.name == "BackgroundMusic") // 원하는 배경 음악 이름으로 변경
            {
                musicSource.clip = music.clip;
            }
        }
    }

    // 배경 음악 재생 메서드
    public void PlayMusic(string name)
    {
        foreach (Sound music in musicSounds)
        {
            if (music.name == name)
            {
                musicSource.clip = music.clip;
                musicSource.Play();
                return;
            }
        }
        Debug.LogWarning("Music with name " + name + " not found.");
    }

    // 효과음 재생 메서드
    public void PlaySFX(string name)
    {
        foreach (Sound sfx in sfxSounds)
        {
             if (sfx.name == name)
            {
                sfxSource.PlayOneShot(sfx.clip);
                if (name == "FootstepSound") // 걷는 소리가 재생 중인지 확인하고 상태 업데이트
                {
                    isFootstepPlaying = true;
                }
                return;
            }
        }
        Debug.LogWarning("SFX with name " + name + " not found.");
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }


    public void StopFootstepSFX()
    {
        if (isFootstepPlaying)
        {
            sfxSource.Stop();
            isFootstepPlaying = false;
        }
    }

    public void StopRunningSFX()
    {
        if (isRunningPlaying)
        {
            sfxSource.Stop();
            isRunningPlaying = false;
        }

    }

    public bool IsFootstepPlaying()
    {
        return isFootstepPlaying;
    }

    public bool IsRunningPlaying()
    {
        return isRunningPlaying;
    }

    public void PlayItemUseSound()
    {
        // 아이템 사용 소리 재생
        PlaySFX("ItemUseSound");
    }

    public void PopupOpenSound()
    {
        // 팝업 열릴 때 소리 재생
        PlaySFX("PopupSound");
    }

}
