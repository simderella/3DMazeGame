using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public ItemClass itemclass;
    



    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Player"))//�±װ� �÷��̾��Ͻ�
        {
            AddToInventoryAndDestoryThis(itemclass);
        }
    }

    // Update is called once per frame
    private void AddToInventoryAndDestoryThis(ItemClass itemclass)//�κ��丮�� �����ϰ� ����
    {
        ItemManager.Instance.Add(itemclass);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
