using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(menuName = "Item/HealthPotion")]
public class HealthPotionClass : ItemClass
{
    public int healAmount;
    public override void Equip()
    {
        UnEquip();
        if (ItemObject != null)
        {

            Transform itemHolder = GameObject.Find("ItemHolder").transform; //Hierarchy�� �ִ� ItemHolder��� transform�� ã�ƿ´�.
            GameObject item = GameObject.Instantiate(ItemObject, itemHolder.position, itemHolder.rotation); //ItemObject�� ItemHolder��ġ�� rotation���� 0���� �����Ѵ�.
            item.transform.GetChild(3).GetComponent<BoxCollider>().enabled = false;//�������� 3���� �ڽ� ������Ʈ�� BoxCollider�� ����
            item.transform.parent = itemHolder.transform;//item�� ItemHolder�� �ڽ����� �����Ѵ�.
            item.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);//������ item�� ũ�⸦ 0.2�� ���δ�.
        }
    }
    public override void Use()
    {
        // ������ ��� �� �Ҹ� ���
        SoundManager.Instance.PlayItemUseSound();

        Equip();

        CharacterHealth characterhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();
        characterhealth.PotionHeal(healAmount);
        itemUsed = true;
    }
}