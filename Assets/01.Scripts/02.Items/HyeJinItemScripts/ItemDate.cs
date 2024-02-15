using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Resource,   //자원
    Equipable,  //장비
    Consumable,  //소모품
    SpeedPotion // 속도 아이템.
}

public enum ConsumableType  //소모품 유형
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
    public int maxStackAmount;  //최대 가질 수 있는 양.

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;

    [Header("Equip")]
    public GameObject equipPrefab;



    [Header("Speed Potion")]    //속도 아이템Duration; 정보
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
