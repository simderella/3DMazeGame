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
        target = player.GetComponent<Transform>();
    }
    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.CompareTag("Player"))

        {
            UIManager.Instance.intutorial = false;
            //UIManager.Instance.RemainSwitch(gameManager.remainswitch);
            target.position = StartPosition.position;
            target.rotation = Quaternion.Euler(0, 0, 0);

        }

    }
}
