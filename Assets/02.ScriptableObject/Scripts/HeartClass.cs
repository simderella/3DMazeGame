using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Heart")]
public class HeartClass : ItemClass
{

    public override void Use()
    {
        Debug.Log("심장사용");
    }
}
