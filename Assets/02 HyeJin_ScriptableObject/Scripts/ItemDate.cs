using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Resource,   //�ڿ�
    Equipable,  //���
    Consumable,  //�Ҹ�ǰ
    SpeedPotion // �ӵ� ������.
}

public enum ConsumableType  //�Ҹ�ǰ ����
{
    Hunger,
    Health,
    Speed
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;  //�ִ� ���� �� �ִ� ��.

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;

    [Header("Equip")]
    public GameObject equipPrefab;



    [Header("Speed Potion")]    //�ӵ� ������Duration; ����
    public float speedUpAmount;
    public float speedPoitonDurationTime;

    public IEnumerator UseSpeedPotion(Player player)
    {
        player.ApplySpeedPotion(speedUpAmount);
        yield return new WaitForSeconds(speedPoitonDurationTime);
        player.ResetSpeed();
    }

    internal void Use()
    {
        throw new NotImplementedException();
    }
}
