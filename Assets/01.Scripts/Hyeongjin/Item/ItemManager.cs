using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject slotsHolder;




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

        slots = new GameObject[slotsHolder.transform.childCount]; //slotholder의 자식 오브잭트의 개수만큼의 배열을 생성

        for (int i = 0; i < slotsHolder.transform.childCount; i++)
        {
            slots[i] = slotsHolder.transform.GetChild(i).gameObject;//slotholder의 자식 오브젝트의 순서대로 번호를 매김
        }
    }


    public void Update()
    {
        RefreshUI();
    }


    public void RefreshUI()//슬롯의 정보를 갱신
    {

        for (int i = 0; i < slotsHolder.transform.childCount; i++)
        {
            slots[i].GetComponent<Slot>().index = i;//슬롯에 달려있는 Slot컴포넌트의 인덱스는 slot의 i번째임
            try
            {
                slots[i].SetActive(true);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].GetComponent<Slot>().item = items[i].GetItem();//Slot컴포넌트의 item은 itemManager의 i번째 아이템임
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
    public void Add(ItemClass item)
    {
        SlotClass slot = Contains(item); //slot이 item을 가지고 있는지 확인
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
        }
    }

    public void Remove(ItemClass item)
    {
        SlotClass temp = Contains(item);
        if (temp != null && temp.GetItem().isStackable)
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
                        slot.GetItem().UnEquip();
                        break;
                    }
                }
                items.Remove(slotToRemove);
            }
        }
    }


    public SlotClass Contains(ItemClass item)//item을 받아서 SlotClass로 반환
    {
        foreach (SlotClass slot in items)//items 리스트의 내부 인덱스 끝까지 반복
        {
            if (slot.GetItem() == item)// slot 내의 item이 인자 item와 같다면
                return slot;//slot을 반환
        }
        return null;//인벤토리가 아이템을 가지고 있지 않음
    }


}
