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
        Debug.Log(player.name);
        target = player.transform;
    }
    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.CompareTag("Player"))

        {
            UIManager.Instance.intutorial = false;
            target.position = StartPosition.position;
            Debug.Log(target.position);
            //target.rotation = Quaternion.Euler(0, 0, 0);

        }

    }
}
