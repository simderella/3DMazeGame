using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(menuName = "Item/Stone")]
public class StoneClass : ItemClass
{
    public override void Equip()
    {
        if (ItemObject != null)
        {
            
            Transform itemHolder = GameObject.Find("ItemHolder").transform; //Hierarchy에 있는 ItemHolder라는 transform을 찾아온다.
            GameObject item = GameObject.Instantiate(ItemObject, itemHolder.position, itemHolder.rotation); //ItemObject를 ItemHolder위치에 rotation값은 0으로 생성한다.
            item.GetComponent<BoxCollider>().enabled = false;//아이템의 BoxCollider를 끈다
            item.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;//아이템의 3번쨰 자식 오브젝트의 BoxCollider를 끈다
            Rigidbody rb = item.GetComponent<Rigidbody>();
            rb.useGravity = false;//중력을 끈다
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;//위치 이동과 회전을 막는다/
            item.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);//생성된 item의 크기를 0.2로 줄인다.
            item.transform.parent = itemHolder.transform;//item을 ItemHolder의 자식으로 생성한다.
        }
    }
    public override void Use()
    {
        Transform itemHolder = GameObject.Find("ItemHolder").transform;//ItemHolder의 transform을 가져온다
        GameObject stone = Instantiate(ItemObject, itemHolder.position, Quaternion.identity);//돌을 생성한다
        stone.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;//닿았을 때 먹지 않도록 한다
        //stone.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//크기를 조절한다
        stone.GetComponent<Rigidbody>().useGravity = true;//중력을 켠다
    }
}
