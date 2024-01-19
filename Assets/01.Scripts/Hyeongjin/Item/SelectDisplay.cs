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
        if (context.started)//�Է¹ޱ� ������ ��. ���ϸ� �Է¹ޱ� �����Ҷ�, �Է¹��� ��, �Է��� ���� �� �� ���� �۵���.
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
                if (ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().item != null)//���� ������ ������ �������� ������
                {
                    ItemManager.Instance.items[CurrentIndex].GetItem().Use();//itemClass�� use�� �ҷ���
                    ItemManager.Instance.Remove(ItemManager.Instance.items[CurrentIndex].GetItem());//���� ������ ������ �������� �Ҹ���
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
        if (ItemManager.Instance.slots[index].GetComponent<Slot>().item != null)//������ index��° ���Կ� Slot������Ʈ�� �������� �ִٸ�
        {
            if (CurrentIndex != index)//������ index�� ���� �ε����� ���� �ʴٸ�
            {
                if(ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().item != null)//CurrentIndex��° ���Կ� Slot������Ʈ�� �������� �ִٸ�
                {
                    ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().Togglehighlightfalse();//���� �������� ���̶���Ʈ ����
                    ItemManager.Instance.items[CurrentIndex].GetItem().UnEquip();//���� ������ ���� ����
                    CurrentIndex = index;//CurrentIndex�� index�� ����
                    ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().Togglehighlighttrue();//���� �������� ���̶���Ʈ �ѱ�
                }
                else//CurrentIndex��° ���Կ� Slot������Ʈ�� �������� ���ٸ� ���� �������� ���̶���Ʈ�� ���ų� ���� �������� ����
                {
                    CurrentIndex = index;
                    ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().Togglehighlighttrue();
                }
            }
            else//������ index�� ���� �ε����� ���ٸ�
            {
                ItemManager.Instance.items[CurrentIndex].GetItem().UnEquip(); //�������� �ߺ� �������� �ʰ� ���� �����ϰ�
                ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().Togglehighlighttrue(); //���̶���Ʈ �ѱ�
            }
            ItemManager.Instance.items[CurrentIndex].GetItem().Equip();//������ �����ϱ�
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
