using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPopup("EscMenu");
        }
    }

    public void ShowPopup(string popupName)
    {
        GameObject escMenu = Resources.Load<GameObject>($"UIPopup/{popupName}");
        Instantiate(escMenu);
    }

    public void ClosePopup(string popupName)
    {
        GameObject escMenu = Resources.Load<GameObject>($"UIPopup/{popupName}");
        Destroy(escMenu);
    }
}
