using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject slotsHolder;




    public List<SlotClass> items = new List<SlotClass>();//slotclassŸ���� ���� items��� ����Ʈ�� �����Ѵ�.
    public GameObject[] slots;//���ӿ�����Ʈ�� ����ϴ� �迭 slot�� �����Ѵ�
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

        slots = new GameObject[slotsHolder.transform.childCount]; //�迭 slots�� ũ��� slotholder�� �ڽ� ������Ʈ�� ����

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
            try //�����ϰ��� �ϴ� ��
            {
                slots[i].SetActive(true);
                slots[i].transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = items[i].GetItem().itemIcon;//i���� ������ �ι�° �ڽĿ�����Ʈ�� �̹��� ��������Ʈ�� itemclass�� itemicon���� �ٲ۴�.
                slots[i].transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = true; //i���� ������ �ι�° �ڽĿ�����Ʈ�� �̹��� ��������Ʈ�� �Ҵ�.
                slots[i].GetComponent<Slot>().item = items[i].GetItem();//Slot������Ʈ�� item�� itemManager�� i��° ��������
                if (items[i].GetItem().isStackable)
                {
                    slots[i].transform.GetChild(2).GetComponent<TMP_Text>().text = items[i].GetQuantity() + "";//���� �ִ� �������� i���� ������ �ι�° �ڽĿ�����Ʈ�� �ؽ�Ʈ�� �������� ������ ǥ���Ѵ�.
                }
                else
                {
                    slots[i].transform.GetChild(2).GetComponent<TMP_Text>().text = "";//���� �ִ� �������� i���� ������ �ι�° �ڽĿ�����Ʈ�� �ؽ�Ʈ�� ǥ������ �ʴ´�.
                }


            }
            catch //����ó��
            {
                slots[i].SetActive(false);//i��° ���Կ� �������� ���ٸ� ������ ����.
                slots[i].GetComponent<Slot>().item = null;//i��° ���Կ� Slot������Ʈ�� item�� null�� �Ѵ�.
                slots[i].transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = null;//i���� ������ �ι�° �ڽĿ�����Ʈ�� �̹��� ��������Ʈ�� null�� �Ѵ�.
                slots[i].transform.GetChild(1).GetChild(0).GetComponent<Image>().enabled = false;//i���� ������ �ι�° �ڽĿ�����Ʈ�� �̹��� ��������Ʈ�� ����.
                slots[i].transform.GetChild(2).GetComponent<TMP_Text>().text = ""; //i���� ������ �ι�° �ڽĿ�����Ʈ�� �ؽ�Ʈ�� ǥ������ �ʴ´�


            }
        }
    }
    public void Add(ItemClass item)
    {
        SlotClass slot = Contains(item); //slot�� item�� ������ �ִ��� Ȯ��
        if (slot != null && slot.GetItem().isStackable)
        {
            slot.AddQuantity(1);//�������� �������� �ϳ��� ���Ѵ�
        }
        else
        {
            if (items.Count < slots.Length)
            {
                items.Add(new SlotClass(item, 1));//���ο� ���Կ� �������� �ϳ� ���Ѵ�.
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
                temp.SubQuantity(1);//�������� �������� �ϳ��� ����
            }
            else
            {
                SlotClass slotToRemove = new SlotClass();
                foreach (SlotClass slot in items)//����Ʈ�� �ִ� slotclass��ŭ �ݺ�
                {
                    if (slot.GetItem() == item)//������ �������� �� �����۰� ���ٸ�
                    {
                        slotToRemove = slot;
                        slot.GetItem().UnEquip();//������ �����Ѵ�
                        break;
                    }
                }
                items.Remove(slotToRemove);//���� �������� �ִ� ������ �����Ѵ�.
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
                temp.SubQuantity(1);//�������� �������� �ϳ��� ����
            }
            else
            {
                SlotClass slotToRemove = new SlotClass();
                foreach (SlotClass slot in items)//����Ʈ�� �ִ� slotclass��ŭ �ݺ�
                {
                    if (slot.GetItem() == item)//������ �������� �� �����۰� ���ٸ�
                    {
                        slotToRemove = slot;
                        slot.GetItem().UnEquip();//������ �����Ѵ�
                        break;
                    }
                }
                items.Remove(slotToRemove);//���� �������� �ִ� ������ �����Ѵ�.
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
