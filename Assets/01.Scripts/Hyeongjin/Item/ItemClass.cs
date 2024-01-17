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
            Transform itemHolder = GameObject.Find("ItemHolder").transform; //Hierarchy에 있는 ItemHolder라는 transform을 찾아온다.
            GameObject item = GameObject.Instantiate(ItemObject, itemHolder.position, Quaternion.identity); //ItemObject를 ItemHolder위치에 rotation값은 0으로 생성한다.
            item.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);//생성된 item의 크기를 0.2로 줄인다.
            item.transform.parent = itemHolder.transform;//item을 ItemHolder의 자식으로 생성한다.
        }
    }

    public virtual void UnEquip()
    {
        Transform itemHolder = GameObject.Find("ItemHolder").transform;
        if (itemHolder.childCount > 0)
        {
            Destroy(itemHolder.GetChild(0).gameObject);
        }
    }

    public virtual void Use()
    {
        Debug.Log("사용");
    }
}
