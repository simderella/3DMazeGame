using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    public int healAmount;  //ü�� ȸ����

    //ü�� ���� ���
    public void UseHealthPotion()
    {
        //ü�� ���� ��� ���� �ʿ�
        Debug.Log("Using health potion: " + itemName + ", Heal Amount: " + healAmount);
    }

}
