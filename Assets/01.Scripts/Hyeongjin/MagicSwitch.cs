using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSwitch : MonoBehaviour
{
    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.CompareTag("Player"))

        {

            this.gameObject.SetActive(false);
            gameManager.remainswitch -= 1;

        }

    }


}
