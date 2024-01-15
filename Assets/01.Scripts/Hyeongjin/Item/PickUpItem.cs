using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public ItemClass itemclass;
    



    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Player"))
        {
            AddToInventoryAndDestoryThis(itemclass);
        }
    }

    // Update is called once per frame
    private void AddToInventoryAndDestoryThis(ItemClass itemclass)
    {
        ItemManager.Instance.Add(itemclass);
        Destroy(gameObject);
    }
}
