using System.Collections;
using UnityEngine;

[System.Serializable]
public class SlotClass //���Գ��� �������� ���� ������ �������� ������ ���� ���� Ŭ����
{
    [SerializeField] private ItemClass item;
    [SerializeField] private int quantity;

    public SlotClass()
    {
        item = null;
        quantity = 0;
    }


    public SlotClass(ItemClass _item, int _quantity)//�����ε�, �Ű������� �ٸ��� �����ϸ� �Ȱ��� �̸��� �Լ��� ��밡��,�޾ƿ��� �Ű������� ���� �׿� �ش��ϴ� �Լ��� ����
    {
        item = _item;
        quantity = _quantity;
    }

    public ItemClass GetItem() { return item; } //ItemClass�� ��ȯ
    public int GetQuantity() { return quantity; } //�������� ������ ��ȯ
    public void AddQuantity(int _quantity) { quantity += _quantity; }
    public void SubQuantity(int _quantity) { quantity -= _quantity; }
}
