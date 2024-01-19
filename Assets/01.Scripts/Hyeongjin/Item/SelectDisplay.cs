using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class SelectDisplay : MonoBehaviour
{
    private int CurrentIndex;
    private Transform itemHolder;



    private void Start()
    {
        itemHolder = GameObject.Find("ItemHolder").transform;
        CurrentIndex = 0;
        ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().Togglehighlighttrue();
        ItemManager.Instance.items[CurrentIndex].GetItem().Equip();
    }

    public void ONHotbar1(InputAction.CallbackContext context)
    {
        if (context.started)//입력받기 시작할 때. 안하면 입력받기 시작할때, 입력받을 때, 입력을 멈출 때 총 세번 작동함.
        {
            SetIndex(0);
        }
    }

    public void ONHotbar2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(1);
        }
    }

    public void ONHotbar3(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(2);
        }
    }

    public void ONHotbar4(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(3);
        }
    }


    public void ONHotbar5(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(4);
        }
    }

    public void ONHotbar6(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(5);
        }
    }

    public void ONHotbar7(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(6);
        }
    }

    public void ONHotbar8(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(7);
        }
    }

    public void ONHotbar9(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(8);
        }
    }

    public void ONUse(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            try
            {
                if (ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().item != null)//현재 선택한 슬롯의 아이템이 있을때
                {
                    ItemManager.Instance.items[CurrentIndex].GetItem().Use();//itemClass의 use를 불러옴
                    ItemManager.Instance.Remove(ItemManager.Instance.items[CurrentIndex].GetItem());//현재 선택한 슬롯의 아이템을 소모함
                    if (ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().item == null)
                    {
                        ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().Togglehighlightfalse();
                    }
                }
            }
            catch 
            {
                ItemManager.Instance.items[CurrentIndex].GetItem().Equip();
                ItemManager.Instance.items[CurrentIndex].GetItem().Use();
                ItemManager.Instance.Remove(ItemManager.Instance.items[CurrentIndex].GetItem());
            }
        }
    }

    public void OnDrop(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ItemManager.Instance.Destroy(ItemManager.Instance.items[CurrentIndex].GetItem());
            
            if (ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().item == null)
            {
                ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().Togglehighlightfalse();
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
            UIManager.Instance.description.text = ItemManager.Instance.items[index].GetItem().description;
        }
        else
        {
            index = 0;
        }
    }
}
