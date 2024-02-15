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
        Transform GunHolder = GameObject.Find("GunHolder").transform; //Hierarchy에 있는 ItemHolder라는 transform을 찾아온다.
        item = GameObject.Instantiate(ItemObject, GunHolder.position, GunHolder.rotation); //ItemObject를 ItemHolder위치에 rotation값은 0으로 생성한다.
        item.transform.localScale = new Vector3(3,3,3);
        item.transform.parent = GunHolder;//item을 ItemHolder의 자식으로 생성한다.
    }

    public override void UnEquip()
    {
        Transform GunHolder = GameObject.Find("GunHolder").transform;//ItemHolder라는 게임 오브젝트를 가지고 옴
        if (GunHolder.childCount > 0)//ItemHolder의 자식 오브젝트가 있을때
        {
            foreach (Transform child in GunHolder)
            {
                Destroy(child.gameObject); //모든 자식 오브젝트 제거
            }
        }
        Transform itemHolder = GameObject.Find("ItemHolder").transform;//ItemHolder라는 게임 오브젝트를 가지고 옴
        if (itemHolder.childCount > 0)//ItemHolder의 자식 오브젝트가 있을때
        {
            foreach (Transform child in itemHolder)
            {
                Destroy(child.gameObject); //모든 자식 오브젝트 제거
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

