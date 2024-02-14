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
                if (ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().item != null)//���� ������ ������ �������� ������
                {
                    ItemManager.Instance.items[CurrentIndex].GetItem().Use();//itemClass�� use�� �ҷ���
                    ItemManager.Instance.Remove(ItemManager.Instance.items[CurrentIndex].GetItem());//���� ������ ������ �������� �Ҹ���

                }
            }
            catch //�տ� �ƹ��͵� ��� ��ħ�� �۵��� �����ߴٸ�
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
            if (ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().item != null)//���� ������ ������ �������� ������
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
            UIManager.Instance.description.text = ItemManager.Instance.items[index].GetItem().description;//������� ������ ItemClass�� �ִ� ������ �ȴ�.
        }
    }

    public void OnUnEquip(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().item != null)//���� ������ ������ �������� ������
            {
                ItemManager.Instance.items[CurrentIndex].GetItem().UnEquip();
            }
        }
    }
}
