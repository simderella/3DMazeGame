using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpeedPotion : Item
{

    public float speedBoostAmount; //�ӵ� ������
    public float duration;  //������ ���� �ð�

    //�ӵ� ���� ���
    public void UseSpeedPotion()
    {
        //�ӵ� ���� ��� ���� �ʿ�.
        Debug.Log("Using speed potion: " + itemName + ", Speed Boost: " + speedBoostAmount);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
