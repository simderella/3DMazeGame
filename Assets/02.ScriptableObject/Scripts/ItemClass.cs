using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;


public class ItemClass : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public bool isStackable;
    public GameObject ItemObject;


    public void Equip()
    {
        if(ItemObject != null)
        {
            Transform itemHolder = GameObject.Find("ItemHolder").transform; //Hierarchy�� �ִ� ItemHolder��� transform�� ã�ƿ´�.
            GameObject item = GameObject.Instantiate(ItemObject, itemHolder.position, Quaternion.identity); //ItemObject�� ItemHolder��ġ�� rotation���� 0���� �����Ѵ�.
            item.GetComponent<BoxCollider>().enabled = false;
            item.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);//������ item�� ũ�⸦ 0.2�� ���δ�.
            item.transform.parent = itemHolder.transform;//item�� ItemHolder�� �ڽ����� �����Ѵ�.
        }
    }

    public void UnEquip()
    {
        Transform itemHolder = GameObject.Find("ItemHolder").transform;//ItemHolder��� ���� ������Ʈ�� ������ ��
        if (itemHolder.childCount > 0)//ItemHolder�� �ڽ� ������Ʈ�� ������
        {
            Destroy(itemHolder.GetChild(0).gameObject);//ItemHolder�� ù��° �ڽĿ�����Ʈ�� ����
        }
    }

    public virtual void Use()//����Ŭ�������� ������ �� �ֵ���
    {
        Debug.Log("���");
    }
}
