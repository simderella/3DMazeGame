using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public GameObject trap;

    public AudioClip trapSound;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null )
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = trapSound;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (trapSound != null && audioSource != null && !trap.activeSelf)
            {
                audioSource.Play();
                trap.SetActive(true);
                StartCoroutine(ResetTrap());
            } 
        }
    }

    private IEnumerator ResetTrap()
    {
        yield return new WaitForSeconds(5f);
        trap.SetActive(false);
    }
}
