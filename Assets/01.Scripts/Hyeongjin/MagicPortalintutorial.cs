using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPortalintutorial : MonoBehaviour
{
    private GameObject player;
    private Transform target;
    public Transform StartPosition;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }
    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.CompareTag("Player"))

        {
            UIManager.Instance.intutorial = false;
            target.position = StartPosition.position;
            Debug.Log("´ê¾Ò´Ù.");

        }

    }
}
