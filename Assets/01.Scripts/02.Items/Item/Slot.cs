using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class Slot : MonoBehaviour
{
    [HideInInspector] public SlotClass slotClass;
    public ItemClass item;
    //private GameObject[] slots;
    public int index;
    public GameObject Highlight;

    
    public void Start()
    {
        //item = ItemManager.Instance.items[index].GetItem();//������ ���Կ� �� ItemClass�� �κ��丮�� ItemManager���� ������ �ε��� ��ȣ�� �°� �������� ��
    }

    public void Togglehighlighttrue()//���̶���Ʈ �ѱ�
    {
        Highlight.SetActive(true);
    }

    public void Togglehighlightfalse()//���̶���Ʈ ����
    {
        Highlight.SetActive(false);
    }

    public void Togglehighlight()//���̶���Ʈ�� ���������� ����
    {
        Highlight.SetActive(!Highlight.activeInHierarchy);
    }
}
