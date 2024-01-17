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
            item.GetComponent<BoxCollider>().enabled = false;
            item.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);//생성된 item의 크기를 0.2로 줄인다.
            item.transform.parent = itemHolder.transform;//item을 ItemHolder의 자식으로 생성한다.
        }
    }

    public void UnEquip()
    {
        Transform itemHolder = GameObject.Find("ItemHolder").transform;//ItemHolder라는 게임 오브젝트를 가지고 옴
        if (itemHolder.childCount > 0)//ItemHolder의 자식 오브젝트가 있을때
        {
            Destroy(itemHolder.GetChild(0).gameObject);//ItemHolder의 첫번째 자식오브젝트를 제거
        }
    }

    public virtual void Use()//하위클래스에서 수정할 수 있도록
    {
        Debug.Log("사용");
    }
}
