using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/CompassEnegyBall")]
public class CompassEnegyBallClass : ItemClass
{

    //public override void Use()
    //{
    //    // ������ ��� �� �Ҹ� ���
    //    SoundManager.Instance.PlayItemUseSound();

    //    Transform usingItem = GameObject.Find("UsingItem").transform;
    //    GameObject compass = GameObject.Instantiate(ItemObject, usingItem.position, usingItem.rotation);
    //    compass.GetComponent<BoxCollider>().enabled = false;//�������� BoxCollider�� ����
    //    compass.transform.GetChild(2).GetComponent<BoxCollider>().enabled = false;//�������� 3���� �ڽ� ������Ʈ�� BoxCollider�� ����
    //    compass.transform.SetParent(usingItem.transform);
    //    compass.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);//������ item�� ũ�⸦ 0.4�� ���δ�.
    //    Compass compassScript = compass.GetComponent<Compass>();
    //    Rigidbody rb = compass.GetComponent<Rigidbody>();
    //    rb.useGravity = false;//�߷��� ����
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
        CompassEnegyBall compassScript = item.GetComponent<CompassEnegyBall>();

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
