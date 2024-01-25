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
            
            Transform itemHolder = GameObject.Find("ItemHolder").transform; //Hierarchy�� �ִ� ItemHolder��� transform�� ã�ƿ´�.
            GameObject item = GameObject.Instantiate(ItemObject, itemHolder.position, itemHolder.rotation); //ItemObject�� ItemHolder��ġ�� rotation���� 0���� �����Ѵ�.
            item.GetComponent<BoxCollider>().enabled = false;//�������� BoxCollider�� ����
            item.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;//�������� 3���� �ڽ� ������Ʈ�� BoxCollider�� ����
            Rigidbody rb = item.GetComponent<Rigidbody>();
            rb.useGravity = false;//�߷��� ����
            rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;//��ġ �̵��� ȸ���� ���´�/
            item.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);//������ item�� ũ�⸦ 0.2�� ���δ�.
            item.transform.parent = itemHolder.transform;//item�� ItemHolder�� �ڽ����� �����Ѵ�.
        }
    }
    public override void Use()
    {
        Transform itemHolder = GameObject.Find("ItemHolder").transform;//ItemHolder�� transform�� �����´�
        GameObject stone = Instantiate(ItemObject, itemHolder.position, Quaternion.identity);//���� �����Ѵ�
        stone.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;//����� �� ���� �ʵ��� �Ѵ�
        //stone.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//ũ�⸦ �����Ѵ�
        stone.GetComponent<Rigidbody>().useGravity = true;//�߷��� �Ҵ�
    }
}
