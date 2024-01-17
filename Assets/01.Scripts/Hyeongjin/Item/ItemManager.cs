using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject slotsHolder;




    public List<SlotClass> items = new List<SlotClass>();//slotclass타입을 갖는 items라는 리스트를 선언한다.
    public GameObject[] slots;//게임오브젝트를 사용하는 배열 slot을 선언한다
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

        slots = new GameObject[slotsHolder.transform.childCount]; //배열 slots의 크기는 slotholder의 자식 오브잭트의 개수

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
            try //실행하고자 하는 것
            {
                slots[i].SetActive(true);
                slots[i].transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;//i번쨰 슬롯의 두번째 자식오브젝트의 이미지 스프라이트를 itemclass의 itemicon으로 바꾼다.
                slots[i].transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = true; //i번쨰 슬롯의 두번째 자식오브젝트의 이미지 스프라이트를 켠다.
                slots[i].GetComponent<Slot>().item = items[i].GetItem();//Slot컴포넌트의 item은 itemManager의 i번째 아이템임
                if (items[i].GetItem().isStackable)
                {
                    slots[i].transform.GetChild(2).GetComponent<TMP_Text>().text = items[i].GetQuantity() + "";//셀수 있는 아이템은 i번쨰 슬롯의 두번째 자식오브젝트의 텍스트를 아이템의 양으로 표시한다.
                }
                else
                {
                    slots[i].transform.GetChild(2).GetComponent<TMP_Text>().text = "";//셀수 있는 아이템은 i번쨰 슬롯의 두번째 자식오브젝트의 텍스트를 표시하지 않는다.
                }


            }
            catch //예외처리
            {
                slots[i].SetActive(false);//i번째 슬롯에 아이템이 없다면 슬롯을 끈다.
                slots[i].GetComponent<Slot>().item = null;//i번째 슬롯에 Slot컴포넌트의 item을 null로 한다.
                slots[i].transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = null;//i번쨰 슬롯의 두번째 자식오브젝트의 이미지 스프라이트를 null로 한다.
                slots[i].transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;//i번쨰 슬롯의 두번째 자식오브젝트의 이미지 스프라이트를 끈다.
                slots[i].transform.GetChild(2).GetComponent<TMP_Text>().text = ""; //i번쨰 슬롯의 두번째 자식오브젝트의 텍스트를 표시하지 않는다


            }
        }
    }
    public void Add(ItemClass item)
    {
        SlotClass slot = Contains(item); //slot이 item을 가지고 있는지 확인
        if (slot != null && slot.GetItem().isStackable)
        {
            slot.AddQuantity(1);//아이템의 수량에서 하나를 더한다
        }
        else
        {
            if (items.Count < slots.Length)
            {
                items.Add(new SlotClass(item, 1));//새로운 슬롯에 아이템을 하나 더한다.
            }
        }
    }

    public void Destroy(ItemClass item)
    {
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            if (temp.GetQuantity() > 1)
            {
                temp.SubQuantity(1);//아이템의 수량에서 하나를 뺀다
            }
            else
            {
                SlotClass slotToRemove = new SlotClass();
                foreach (SlotClass slot in items)//리스트에 있는 slotclass만큼 반복
                {
                    if (slot.GetItem() == item)//슬롯의 아이템이 뺄 아이템과 같다면
                    {
                        slotToRemove = slot;
                        slot.GetItem().UnEquip();//장착을 해제한다
                        break;
                    }
                }
                items.Remove(slotToRemove);//같은 아이템이 있던 슬롯을 제거한다.
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
                temp.SubQuantity(1);//아이템의 수량에서 하나를 뺀다
            }
            else
            {
                SlotClass slotToRemove = new SlotClass();
                foreach (SlotClass slot in items)//리스트에 있는 slotclass만큼 반복
                {
                    if (slot.GetItem() == item)//슬롯의 아이템이 뺄 아이템과 같다면
                    {
                        slotToRemove = slot;
                        slot.GetItem().UnEquip();//장착을 해제한다
                        break;
                    }
                }
                items.Remove(slotToRemove);//같은 아이템이 있던 슬롯을 제거한다.
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
