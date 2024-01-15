using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectDisplay : MonoBehaviour
{
    private int CurrentIndex;

    private void Start()
    {
        CurrentIndex = 0;
        SetIndex(0);
    }

    public void ONHotbar1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(0);
        }
    }

    public void ONHotbar2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(1);
        }
    }

    public void ONHotbar3(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(2);
        }
    }

    public void ONHotbar4(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(3);
        }
    }


    public void ONHotbar5(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(4);
        }
    }

    public void ONHotbar6(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(5);
        }
    }

    public void ONHotbar7(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(6);
        }
    }

    public void ONHotbar8(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(7);
        }
    }

    public void ONHotbar9(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SetIndex(8);
        }
    }

    public void ONUse(InputAction.CallbackContext context)
    {
        if (ItemManager.Instance.items[CurrentIndex] != null)
        {
            ItemManager.Instance.items[CurrentIndex].GetItem().Use();
        }
    }
    private void SetIndex(int index)
    {
        Debug.Log(CurrentIndex + "+" + index);
        if(CurrentIndex != index)
        {
        ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().Togglehighlightfalse();
        CurrentIndex = index;
        ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().Togglehighlighttrue();
        }
        else
        {
            ItemManager.Instance.slots[CurrentIndex].GetComponent<Slot>().Togglehighlight();
        }
    }
}
