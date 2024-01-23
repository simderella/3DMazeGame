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

    public void OnHotBar1()
    {
            SetIndex(0);

    }

    public void OnHotBar2()
    {
            SetIndex(1);
    }

    public void OnHotBar3()
    {
 
            SetIndex(2);

    }

    public void OnHotBar4()
    {

            SetIndex(3);

    }


    public void OnHotBar5()
    {
            SetIndex(4);
    }

    public void OnHotBar6()
    {

            SetIndex(5);

    }

    public void OnHotBar7()
    {

            SetIndex(6);

    }

    public void OnHotBar8()
    {

            SetIndex(7);

    }

    public void OnHotBar9()
    {

        SetIndex(8);

    }

    public void OnUse()
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

    public void OnDrop()
    {

            ItemManager.Instance.Destroy(ItemManager.Instance.items[CurrentIndex].GetItem());

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
}
