using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(menuName = "Item/Compass")]
public class CompassClass : ItemClass
{

    public override void Use()
    {
        GameObject compass = item;
        Compass compassScript = compass.GetComponent<Compass>();
        if (compassScript.useCompass == false)
        {
            compassScript.useCompass = true;

        }


        //Transform itemHolder = GameObject.Find("ItemHolder").transform;//ItemHolder�� transform�� �����´�
        //GameObject compass = Instantiate(ItemObject, itemHolder.position, Quaternion.identity);//��ħ���� �����Ѵ�
        //compass.transform.GetChild(2).GetComponent<BoxCollider>().enabled = false;//����� �� ���� �ʵ��� �Ѵ�
        //Rigidbody rb = compass.GetComponent<Rigidbody>();
        //rb.useGravity = true;//�߷��� �Ҵ�
    }
}
