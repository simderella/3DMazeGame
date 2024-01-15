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
        item = ItemManager.Instance.items[index].GetItem();
    }

    public void Togglehighlighttrue()
    {
        Highlight.SetActive(true);
    }

    public void Togglehighlightfalse()
    {
        Highlight.SetActive(false);
    }

    public void Togglehighlight()
    {
        Highlight.SetActive(!Highlight.activeInHierarchy);
    }
}
