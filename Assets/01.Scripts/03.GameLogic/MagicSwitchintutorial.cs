using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSwitchintutorial : MonoBehaviour
{
    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.CompareTag("Player"))

        {

            this.gameObject.SetActive(false);
            gameManager.remainswitchintutorial -= 1;

        }

    }


}
