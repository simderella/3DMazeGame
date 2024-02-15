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
        //item = ItemManager.Instance.items[index].GetItem();//각각의 슬롯에 들어갈 ItemClass는 인벤토리의 ItemManager에서 지정한 인덱스 번호에 맞게 아이템이 들어감
    }

    public void Togglehighlighttrue()//하이라이트 켜기
    {
        Highlight.SetActive(true);
    }

    public void Togglehighlightfalse()//하이라이트 끄기
    {
        Highlight.SetActive(false);
    }

    public void Togglehighlight()//하이라이트가 켜저있으면 끄기
    {
        Highlight.SetActive(!Highlight.activeInHierarchy);
    }
}
