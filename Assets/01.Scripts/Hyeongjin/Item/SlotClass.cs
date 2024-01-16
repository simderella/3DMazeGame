using System.Collections;
using UnityEngine;

[System.Serializable]
public class SlotClass //슬롯내에 아이템이 존재 유무와 아이템의 개수를 세기 위한 클래스
{
    [SerializeField] private ItemClass item;
    [SerializeField] private int quantity;

    public SlotClass()
    {
        item = null;
        quantity = 0;
    }


    public SlotClass(ItemClass _item, int _quantity)
    {
        item = _item;
        quantity = _quantity;
    }

    public ItemClass GetItem() { return item; } //ItemClass를 반환
    public int GetQuantity() { return quantity; } //아이템의 개수를 반환
    public void AddQuantity(int _quantity) { quantity += _quantity; }
    public void SubQuantity(int _quantity) { quantity -= _quantity; }
}
