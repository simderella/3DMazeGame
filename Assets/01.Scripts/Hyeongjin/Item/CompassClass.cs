using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Compass")]
public class CompassClass : ItemClass
{

    public override void Use()
    {
        Debug.Log("나침반 사용");
    }
}
