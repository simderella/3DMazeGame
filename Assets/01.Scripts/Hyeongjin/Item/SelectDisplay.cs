using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class SelectDisplay : MonoBehaviour
{
    private int CurrentIndex;
    private Transform itemHolder;



    private void Start()
    {
        itemHolder = GameObject.Find("ItemHolder").transform;
        CurrentIndex = 0;
        ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().Togglehighlighttrue();
        //ItemManager.Instance.items[CurrentIndex].GetItem().Equip();
    }

    public void OnHotBar1(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            SetIndex(0);
        }
    }

    public void OnHotBar2(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            SetIndex(1);
        }
    }

    public void OnHotBar3(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            SetIndex(2);
        }
    }

    public void OnHotBar4(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            SetIndex(3);
        }
    }


    public void OnHotBar5(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            SetIndex(4);
        }
    }
    public void OnHotBar6(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            SetIndex(5);
        }
    }
    public void OnHotBar7(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            SetIndex(6);
        }
    }
    public void OnHotBar8(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            SetIndex(7);
        }
    }
    public void OnHotBar9(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            SetIndex(8);
        }
    }


    public void OnUse(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            try
            {
                if (ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().item != null)//현재 선택한 슬롯의 아이템이 있을때
                {
                    ItemManager.Instance.items[CurrentIndex].GetItem().Use();//itemClass의 use를 불러옴
                    ItemManager.Instance.Remove(ItemManager.Instance.items[CurrentIndex].GetItem());//현재 선택한 슬롯의 아이템을 소모함

                }
            }
            catch //손에 아무것도 없어서 나침반 작동이 실패했다면
            {
                ItemManager.Instance.items[CurrentIndex].GetItem().Equip();
                ItemManager.Instance.items[CurrentIndex].GetItem().Use();
                //ItemManager.Instance.Remove(ItemManager.Instance.items[CurrentIndex].GetItem());
            }
        }
    }

    public void OnDrop(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().item != null)//현재 선택한 슬롯의 아이템이 있을때
            {
                ItemManager.Instance.Destroy(ItemManager.Instance.items[CurrentIndex].GetItem());
            }
        }
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if(ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().item != null)
            {
                ItemManager.Instance.items[CurrentIndex].GetItem().Shoot();
            }
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            if (ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().item != null)
            {
                ItemManager.Instance.items[CurrentIndex].GetItem().StopShoot();

            }

        }

    }

    private void SetIndex(int index)
    { 
        if (ItemManager.Instance.slots[index].GetComponent<Slot>().item != null)//선택한 index번째 슬롯에 Slot컴포넌트에 아이템이 있다면
        {
            if (CurrentIndex != index)//선택한 index가 이전 인덱스와 같지 않다면
            {
                if(ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().item != null)//CurrentIndex번째 슬롯에 Slot컴포넌트에 아이템이 있다면
                {
                    ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().Togglehighlightfalse();//이전 아이템의 하이라이트 끄기
                    ItemManager.Instance.items[CurrentIndex].GetItem().UnEquip();//이전 아이템 장착 해제
                    CurrentIndex = index;//CurrentIndex를 index로 갱신
                    ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().Togglehighlighttrue();//현재 아이템의 하이라이트 켜기
                }
                else//CurrentIndex번째 슬롯에 Slot컴포넌트에 아이템이 없다면 이전 아이템의 하이라이트를 끄거나 장착 해제하지 않음
                {
                    CurrentIndex = index;
                    ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().Togglehighlighttrue();
                }
            }
            else//선택한 index가 이전 인덱스와 같다면
            {
                ItemManager.Instance.items[CurrentIndex].GetItem().UnEquip(); //아이템이 중복 생성되지 않게 장착 해제하고
                ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().Togglehighlighttrue(); //하이라이트 켜기
            }
            ItemManager.Instance.items[CurrentIndex].GetItem().Equip();//아이템 장착하기
            Descript(index);

        }

    }
    private void Descript(int index)
    {
        if (index >= 0)
        {
            UIManager.Instance.description.text = ItemManager.Instance.items[index].GetItem().description;//설명란의 설명은 ItemClass에 있는 설명이 된다.
        }
    }

    public void OnUnEquip(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().item != null)//현재 선택한 슬롯의 아이템이 있을때
            {
                ItemManager.Instance.items[CurrentIndex].GetItem().UnEquip();
            }
        }
    }
}
