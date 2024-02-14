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
        if (ItemObject != null)
        {

            Transform itemHolder = GameObject.Find("ItemHolder").transform; //Hierarchy에 있는 ItemHolder라는 transform을 찾아온다.
            GameObject item = GameObject.Instantiate(ItemObject, itemHolder.position, Quaternion.identity); //ItemObject를 ItemHolder위치에 rotation값은 0으로 생성한다.
            item.transform.GetChild(3).GetComponent<BoxCollider>().enabled = false;//아이템의 3번쨰 자식 오브젝트의 BoxCollider를 끈다
            item.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);//생성된 item의 크기를 0.2로 줄인다.
            item.transform.parent = itemHolder.transform;//item을 ItemHolder의 자식으로 생성한다.
        }
    }
    public override void Use()
    {
        // 아이템 사용 시 소리 재생
        SoundManager.Instance.PlayItemUseSound();

        CharacterHealth characterhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();
        characterhealth.PotionHeal(healAmount);
        itemUsed = true;
    }
}
