using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Compass")]
public class CompassClass : ItemClass
{
    public override void Equip()
    {
        base.Equip();
    }
    public override void Use()
    {
        Debug.Log("��ħ�� ���");
    }
}
