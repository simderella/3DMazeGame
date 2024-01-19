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


        //Transform itemHolder = GameObject.Find("ItemHolder").transform;//ItemHolder의 transform을 가져온다
        //GameObject compass = Instantiate(ItemObject, itemHolder.position, Quaternion.identity);//나침반을 생성한다
        //compass.transform.GetChild(2).GetComponent<BoxCollider>().enabled = false;//닿았을 때 먹지 않도록 한다
        //Rigidbody rb = compass.GetComponent<Rigidbody>();
        //rb.useGravity = true;//중력을 켠다
    }
}
