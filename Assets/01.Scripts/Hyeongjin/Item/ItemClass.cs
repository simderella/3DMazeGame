using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class ItemClass : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public bool isStackable;

    public virtual void Use()
    {
        Debug.Log("»ç¿ë");
    }
}
