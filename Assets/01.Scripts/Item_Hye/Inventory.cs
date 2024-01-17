using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSlot
{
    public ItemData item;
    public int quantity;
}
public class Inventory : MonoBehaviour
{
    public ItemSlotUI[] uiSlots;
    public ItemSlot[] slot;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
