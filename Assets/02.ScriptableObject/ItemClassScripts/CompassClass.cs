using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(menuName = "Item/Compass")]
public class CompassClass : ItemClass
{

    //public override void Use()
    //{
    //    // 아이템 사용 시 소리 재생
    //    SoundManager.Instance.PlayItemUseSound();

    //    Transform usingItem = GameObject.Find("UsingItem").transform;
    //    GameObject compass = GameObject.Instantiate(ItemObject, usingItem.position, usingItem.rotation);
    //    compass.GetComponent<BoxCollider>().enabled = false;//아이템의 BoxCollider를 끈다
    //    compass.transform.GetChild(2).GetComponent<BoxCollider>().enabled = false;//아이템의 3번쨰 자식 오브젝트의 BoxCollider를 끈다
    //    compass.transform.SetParent(usingItem.transform);
    //    compass.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);//생성된 item의 크기를 0.4로 줄인다.
    //    Compass compassScript = compass.GetComponent<Compass>();
    //    Rigidbody rb = compass.GetComponent<Rigidbody>();
    //    rb.useGravity = false;//중력을 끈다
    //    rb.constraints = RigidbodyConstraints.FreezePosition;
    //    if (compassScript.useCompass == false)
    //    {
    //        compassScript.useCompass = true;
    //    }
    //    itemUsed = true;
    //}

    public override void Use()
    {
        SoundManager.Instance.PlayItemUseSound();
        Compass compassScript = item.GetComponent<Compass>();

        if (compassScript.useCompass == false)
        {
            compassScript.useCompass = true;
            itemUsed = true;
            compassUsed = true;
        }
        else
        {
            itemUsed = false;
            compassUsed = false;
        }
    }
}
