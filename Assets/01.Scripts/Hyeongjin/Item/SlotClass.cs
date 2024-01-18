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


    public SlotClass(ItemClass _item, int _quantity)//오버로딩, 매개변수를 다르게 설정하면 똑같은 이름의 함수를 사용가능,받아오는 매개변수에 따라 그에 해당하는 함수가 실행
    {
        item = _item;
        quantity = _quantity;
    }

    public ItemClass GetItem() { return item; } //ItemClass를 반환
    public int GetQuantity() { return quantity; } //아이템의 개수를 반환
    public void AddQuantity(int _quantity) { quantity += _quantity; }
    public void SubQuantity(int _quantity) { quantity -= _quantity; }
}
