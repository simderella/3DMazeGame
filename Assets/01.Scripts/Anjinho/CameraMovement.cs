using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class CameraMovement : MonoBehaviour
{
    public GameObject capsule;
    private Vector3 pos = new Vector3(0, 20, 0);

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = capsule.transform.position + pos; 
    }

}
