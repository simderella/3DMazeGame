using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject slotsHolder;
    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;



    public List<SlotClass> items = new List<SlotClass>();
    public GameObject[] slots;
    private static ItemManager _instance;

    public static ItemManager Instance
    {
        get
        {

            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(ItemManager)) as ItemManager;
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        slots = new GameObject[slotsHolder.transform.childCount];

        for (int i = 0; i < slotsHolder.transform.childCount; i++)
        {
            slots[i] = slotsHolder.transform.GetChild(i).gameObject;
        }
        Add(itemToAdd);
        Remove(itemToRemove);
    }


    public void Update()
    {
        RefreshUI();
    }


    public void RefreshUI()
    {

        for (int i = 0; i < slotsHolder.transform.childCount; i++)
        {
            slots[i].GetComponent<Slot>().index = i;
            try
            {
                slots[i].SetActive(true);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].GetComponent<Slot>().item = items[i].GetItem();
                //slots[i].GetComponent<Slot>().index = i;
                if (items[i].GetItem().isStackable)
                {
                    slots[i].transform.GetChild(2).GetComponent<TMP_Text>().text = items[i].GetQuantity() + "";
                }
                else
                {
                    slots[i].transform.GetChild(2).GetComponent<TMP_Text>().text = "";
                }


            }
            catch
            {
                slots[i].SetActive(false);
                slots[i].GetComponent<Slot>().item = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(2).GetComponent<TMP_Text>().text = "";
                
            }
        }
    }
    public bool Add(ItemClass item)
    {
        //items.Add(item);
        SlotClass slot = Contains(item);
        if (slot != null && slot.GetItem().isStackable)
        {
            slot.AddQuantity(1);
        }
        else
        {
            if (items.Count < slots.Length)
            {
                items.Add(new SlotClass(item, 1));
            }
            else
            {
                return false;
            }
        }
        RefreshUI();
        return true;
    }

    public bool Remove(ItemClass item)
    {
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            if (temp.GetQuantity() > 1)
            {
                temp.SubQuantity(1);
            }
            else
            {
                SlotClass slotToRemove = new SlotClass();
                foreach (SlotClass slot in items)
                {
                    if (slot.GetItem() == item)
                    {
                        slotToRemove = slot;
                        break;
                    }
                }
                items.Remove(slotToRemove);
            }
        }
        else
        {
            return false;
        }

        RefreshUI();
        return true;
    }


    public SlotClass Contains(ItemClass item)
    {
        foreach (SlotClass slot in items)
        {
            if (slot.GetItem() == item)
                return slot;
        }
        return null;
    }


}
