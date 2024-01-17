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

        slots = new GameObject[slotsHolder.transform.childCount]; //slotholder�� �ڽ� ������Ʈ�� ������ŭ�� �迭�� ����

        for (int i = 0; i < slotsHolder.transform.childCount; i++)
        {
            slots[i] = slotsHolder.transform.GetChild(i).gameObject;//slotholder�� �ڽ� ������Ʈ�� ������� ��ȣ�� �ű�
        }
    }


    public void Update()
    {
        RefreshUI();
    }


    public void RefreshUI()//������ ������ ����
    {

        for (int i = 0; i < slotsHolder.transform.childCount; i++)
        {
            slots[i].GetComponent<Slot>().index = i;//���Կ� �޷��ִ� Slot������Ʈ�� �ε����� slot�� i��°��
            try
            {
                slots[i].SetActive(true);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].GetComponent<Slot>().item = items[i].GetItem();//Slot������Ʈ�� item�� itemManager�� i��° ��������
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
        SlotClass slot = Contains(item); //slot�� item�� ������ �ִ��� Ȯ��
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


    public SlotClass Contains(ItemClass item)//item�� �޾Ƽ� SlotClass�� ��ȯ
    {
        foreach (SlotClass slot in items)//items ����Ʈ�� ���� �ε��� ������ �ݺ�
        {
            if (slot.GetItem() == item)// slot ���� item�� ���� item�� ���ٸ�
                return slot;//slot�� ��ȯ
        }
        return null;//�κ��丮�� �������� ������ ���� ����
    }


}
