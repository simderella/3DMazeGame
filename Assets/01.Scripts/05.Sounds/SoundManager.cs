using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;


    // ���� ������ ��� Ŭ����
    [System.Serializable]
    public class Sound
    {
        public string name; // ���� �̸�
        public AudioClip clip; // ����� Ŭ��
    }

    // ��� ������ ���� �迭
    public Sound[] musicSounds;
    // ȿ������ ���� �迭
    public Sound[] sfxSounds;

    // ��� ������ ����� AudioSource
    public AudioSource musicSource;
    // ȿ������ ����� AudioSource
    public AudioSource sfxSource;

    public AudioClip normalBackgroundClip;
    public AudioClip enemyBackgroundClip;

    private AudioClip previousClip; // ���� ��� ������ �����ϱ� ���� ����

    private bool isFootstepPlaying = false; // �ȴ� �Ҹ��� ���� ��� ������ ����
    private bool isRunningPlaying = false;  // �޸��� �Ҹ��� ���� ��� ������ ����


    private void Awake()
    {
        // ���� �Ŵ��� �ν��Ͻ� ����
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
            // ��� ���� �ʱ�ȭ
            if (music.name == "BackgroundMusic") // ���ϴ� ��� ���� �̸����� ����
            {
                musicSource.clip = music.clip;
            }
        }

        // ��� ���� �ʱ�ȭ
        musicSource.clip = normalBackgroundClip;
        musicSource.Play();
    }

    // ��� ���� ��� �޼���
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

    // ȿ���� ��� �޼���
    public void PlaySFX(string name)
    {
        foreach (Sound sfx in sfxSounds)
        {
             if (sfx.name == name)
            {
                sfxSource.PlayOneShot(sfx.clip);
                if (name == "FootstepSound") // �ȴ� �Ҹ��� ��� ������ Ȯ���ϰ� ���� ������Ʈ
                {
                    sfxSource.PlayOneShot(sfx.clip);
                    isFootstepPlaying = true;
                }
                else if (name == "RunningSound")
                {
                    if (!isRunningPlaying)  // ������ �޸��� �Ҹ��� ��� ���� �ƴ� ��쿡�� ���
                    {
                        sfxSource.PlayOneShot(sfx.clip);
                        isRunningPlaying = true; // ���� ���� ������Ʈ
                    }
                }
                else
                {
                    sfxSource.PlayOneShot(sfx.clip);
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
        // ������ ��� �Ҹ� ���
        PlaySFX("ItemUseSound");
    }

    public void PopupOpenSound()
    {
        // �˾� ���� �� �Ҹ� ���
        PlaySFX("PopupSound");
    }

    // �÷��̾�� �� ������ �Ÿ��� ����Ͽ� ��� ���� ����
    public void UpdateBackgroundMusic(Vector3 playerPosition, Vector3 enemyPosition, float detectionRange)
    {
        float distanceToEnemy = Vector3.Distance(playerPosition, enemyPosition);

        if (distanceToEnemy <= detectionRange)
        {
            if (musicSource.clip != enemyBackgroundClip)
            {
                previousClip = musicSource.clip; // ���� ��� ���� ����
                musicSource.clip = enemyBackgroundClip;
                musicSource.Play();
            }
        }
        else
        {
            if (musicSource.clip != normalBackgroundClip)
            {
                previousClip = musicSource.clip; // ���� ��� ���� ����
                musicSource.clip = normalBackgroundClip;
                musicSource.Play();
            }
        }
    }

    // ������ ��� �������� ����
    public void RestoreBackgroundMusic()
    {
        if (previousClip != null)
        {
            musicSource.clip = previousClip;
            musicSource.Play();
        }
    }

}
