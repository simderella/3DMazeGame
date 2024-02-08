using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }
    public override void Use()
    {
        gun = item.GetComponent<Gun>();
        gun.Reload();
    }
    public override void Shoot()
    {
        gun = item.GetComponent<Gun>();
        gun.shooting = true;
    }

    public override void StopShoot() 
    {
        gun = item.GetComponent<Gun>();
        gun.shooting = false;
    }
}
