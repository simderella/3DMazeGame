using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/SpeedItem")]
public class SpeedItemClass : ItemClass
{
    public float speedBoostAmount = 4f; // 이동 속도 증가량
    public float duration = 15f; // 스피드 포션 지속 시간

    public override void Equip()
    {
        UnEquip();
        if (ItemObject != null)
        {

            Transform itemHolder = GameObject.Find("ItemHolder").transform; //Hierarchy에 있는 ItemHolder라는 transform을 찾아온다.
            GameObject item = GameObject.Instantiate(ItemObject, itemHolder.position, itemHolder.rotation); //ItemObject를 ItemHolder위치에 rotation값은 0으로 생성한다.
            item.transform.GetChild(3).GetComponent<BoxCollider>().enabled = false;//아이템의 3번쨰 자식 오브젝트의 BoxCollider를 끈다
            item.transform.parent = itemHolder.transform;//item을 ItemHolder의 자식으로 생성한다.
            item.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);//생성된 item의 크기를 0.2로 줄인다.
        }
    }
    public override void Use()
    {
        // 아이템 사용 시 소리 재생
        SoundManager.Instance.PlayItemUseSound();

        Equip();
        // 플레이어 컨트롤러를 찾아서 스피드 포션을 적용
        CharacterStamina characterStamina = GameObject.FindObjectOfType<CharacterStamina>();
        if (characterStamina != null && characterStamina.boostOn == false)
        {
            characterStamina.ApplySpeedPotion(speedBoostAmount, duration);
            Debug.Log("스피드 포션을 사용했다.");
            itemUsed = true;
        }
        else
        {
            itemUsed = false;
        }
    }
}
