using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public ItemClass itemclass;
    



    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Player"))//태그가 플레이어일시
        {
            AddToInventoryAndDestoryThis(itemclass);
        }
    }

    // Update is called once per frame
    private void AddToInventoryAndDestoryThis(ItemClass itemclass)//인벤토리에 저장하고 제거
    {
        ItemManager.Instance.Add(itemclass);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
