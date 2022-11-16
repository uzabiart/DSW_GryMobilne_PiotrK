using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{
    public Image art;
    public ItemData item;
    public bool IsOccupied { get; private set; }

    public void SetupItem(ItemData item)
    {
        art.gameObject.SetActive(true);
        art.sprite = item.art;
        art.SetNativeSize();
        IsOccupied = true;
    }
    public void ThrowItem()
    {
        art.gameObject.SetActive(false);
        IsOccupied = false;
    }
}