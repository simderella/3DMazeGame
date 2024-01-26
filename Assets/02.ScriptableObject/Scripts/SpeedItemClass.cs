using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(menuName = "Item/SpeedItem")]
public class SpeedItemClass : ItemClass
{
    public float speedBoostAmount = 3f; // �̵� �ӵ� ������
    public float duration = 5f; // ���ǵ� ���� ���� �ð�

    public override void Equip()
    {
        if (ItemObject != null)
        {

            Transform itemHolder = GameObject.Find("ItemHolder").transform; //Hierarchy�� �ִ� ItemHolder��� transform�� ã�ƿ´�.
            GameObject item = GameObject.Instantiate(ItemObject, itemHolder.position, Quaternion.identity); //ItemObject�� ItemHolder��ġ�� rotation���� 0���� �����Ѵ�.
            item.transform.GetChild(3).GetComponent<BoxCollider>().enabled = false;//�������� 3���� �ڽ� ������Ʈ�� BoxCollider�� ����
            item.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);//������ item�� ũ�⸦ 0.2�� ���δ�.
            item.transform.parent = itemHolder.transform;//item�� ItemHolder�� �ڽ����� �����Ѵ�.
        }
    }
    public override void Use()
    {
        // �÷��̾� ��Ʈ�ѷ��� ã�Ƽ� ���ǵ� ������ ����
        PlayerController playerController = GameObject.FindObjectOfType<PlayerController>();
        if (playerController != null)
        {
            playerController.ApplySpeedPotion(speedBoostAmount, duration);
            Debug.Log("���ǵ� ������ ����ߴ�.");
        }
    }
}
