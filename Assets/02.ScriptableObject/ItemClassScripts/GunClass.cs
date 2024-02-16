using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

[CreateAssetMenu(menuName = "Item/gun")]
public class GunClass : ItemClass
{
    public int damage;
    public float timeBetweenShooting, spread, range, reloadtime, timeBetweenShots;
    public int magazineSize, BulletPerTaps;
    private Gun gun;

    public override void Equip()
    {
        UnEquip();
        Transform GunHolder = GameObject.Find("GunHolder").transform; //Hierarchy�� �ִ� ItemHolder��� transform�� ã�ƿ´�.
        item = GameObject.Instantiate(ItemObject, GunHolder.position, GunHolder.rotation); //ItemObject�� ItemHolder��ġ�� rotation���� 0���� �����Ѵ�.
        item.transform.localScale = new Vector3(3,3,3);
        item.transform.parent = GunHolder;//item�� ItemHolder�� �ڽ����� �����Ѵ�.
    }

    public override void UnEquip()
    {
        Transform GunHolder = GameObject.Find("GunHolder").transform;//ItemHolder��� ���� ������Ʈ�� ������ ��
        if (GunHolder.childCount > 0)//ItemHolder�� �ڽ� ������Ʈ�� ������
        {
            foreach (Transform child in GunHolder)
            {
                Destroy(child.gameObject); //��� �ڽ� ������Ʈ ����
            }
        }
        Transform itemHolder = GameObject.Find("ItemHolder").transform;//ItemHolder��� ���� ������Ʈ�� ������ ��
        if (itemHolder.childCount > 0)//ItemHolder�� �ڽ� ������Ʈ�� ������
        {
            foreach (Transform child in itemHolder)
            {
                Destroy(child.gameObject); //��� �ڽ� ������Ʈ ����
            }
        }
    }
    public override void Use()
    {
        Transform GunHolder = GameObject.Find("GunHolder").transform;
        if (GunHolder.childCount == 0)
        {
            Equip();
        }
        gun = item.GetComponent<Gun>();
        gun.Reload();
    }
    public override void Shoot()
    {
        Transform GunHolder = GameObject.Find("GunHolder").transform;
        if (GunHolder.childCount == 0)
        {
            Equip();
        }
        gun = item.GetComponent<Gun>();
        gun.shooting = true;
    }

    public override void StopShoot() 
    {
        gun = item.GetComponent<Gun>();
        gun.shooting = false;
    }
}

