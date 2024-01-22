using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;


public class ItemClass : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public bool isStackable;
    public GameObject ItemObject;
    public GameObject item { get; private set; }
    [Multiline]
    public string description;


    public virtual void Equip()
    {
        if(ItemObject != null)
        {
            Transform itemHolder = GameObject.Find("ItemHolder").transform; //Hierarchy�� �ִ� ItemHolder��� transform�� ã�ƿ´�.
            item = GameObject.Instantiate(ItemObject, itemHolder.position, Quaternion.identity); //ItemObject�� ItemHolder��ġ�� rotation���� 0���� �����Ѵ�.
            item.GetComponent<BoxCollider>().enabled = false;//�������� BoxCollider�� ����
            item.transform.GetChild(2).GetComponent<BoxCollider>().enabled = false;//�������� 3���� �ڽ� ������Ʈ�� BoxCollider�� ����
            item.GetComponent<Rigidbody>().useGravity = false;
            item.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);//������ item�� ũ�⸦ 0.2�� ���δ�.
            item.transform.parent = itemHolder.transform;//item�� ItemHolder�� �ڽ����� �����Ѵ�.
        }
    }

    public void UnEquip()
    {
        Transform itemHolder = GameObject.Find("ItemHolder").transform;//ItemHolder��� ���� ������Ʈ�� ������ ��
        if (itemHolder.childCount > 0)//ItemHolder�� �ڽ� ������Ʈ�� ������
        {
            foreach (Transform child in itemHolder)
            {
                Destroy(child.gameObject); //��� �ڽ� ������Ʈ ����
            }
        }
    }

    public virtual void Use()//����Ŭ�������� ������ �� �ֵ���
    {
        return;
    }
}
