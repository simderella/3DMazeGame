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
    [HideInInspector]public GameObject item;
    [HideInInspector] public bool itemUsed;
    [HideInInspector] public bool compassUsed;
    [Multiline]
    public string description;


    public virtual void Equip()
    {
        UnEquip();
        if(ItemObject != null)
        {
            Transform itemHolder = GameObject.Find("ItemHolder").transform; //Hierarchy�� �ִ� ItemHolder��� transform�� ã�ƿ´�.
            item = GameObject.Instantiate(ItemObject, itemHolder.position, itemHolder.rotation); //ItemObject�� ItemHolder��ġ�� rotation���� 0���� �����Ѵ�.
            item.GetComponent<BoxCollider>().enabled = false;//�������� BoxCollider�� ����
            item.transform.GetChild(2).GetComponent<BoxCollider>().enabled = false;//�������� 3���� �ڽ� ������Ʈ�� BoxCollider�� ����
            item.GetComponent<Rigidbody>().useGravity = false;
            Rigidbody rb = item.GetComponent<Rigidbody>();
            rb.useGravity = false;//�߷��� ����
            rb.constraints = RigidbodyConstraints.FreezePosition;
            item.transform.parent = itemHolder.transform;//item�� ItemHolder�� �ڽ����� �����Ѵ�.
            item.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);//������ item�� ũ�⸦ 0.2�� ���δ�.

        }
    }

    public virtual void UnEquip()
    {
        Transform itemHolder = GameObject.Find("ItemHolder").transform;//ItemHolder��� ���� ������Ʈ�� ������ ��
        if (itemHolder.childCount > 0)//ItemHolder�� �ڽ� ������Ʈ�� ������
        {
            foreach (Transform child in itemHolder)
            {
                Destroy(child.gameObject); //��� �ڽ� ������Ʈ ����
            }
        }
        Transform GunHolder = GameObject.Find("GunHolder").transform;//ItemHolder��� ���� ������Ʈ�� ������ ��
        if (GunHolder.childCount > 0)//ItemHolder�� �ڽ� ������Ʈ�� ������
        {
            foreach (Transform child in GunHolder)
            {
                Destroy(child.gameObject); //��� �ڽ� ������Ʈ ����
            }
        }
    }

    public virtual void Use()//����Ŭ�������� ������ �� �ֵ���
    {
        return;
    }

    public virtual void Shoot()
    {

    }

    public virtual void StopShoot()
    {

    }
}