using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    public int healAmount;  //체력 회복량

    //체력 포션 사용
    public void UseHealthPotion()
    {
        //체력 포션 사용 로직 필요
        Debug.Log("Using health potion: " + itemName + ", Heal Amount: " + healAmount);
    }

}
