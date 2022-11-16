using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public SlotItem[] slotItems;
    private GameObject panel;

    private void Awake()
    {
        panel = transform.GetChild(0).gameObject;
        Hide();
        slotItems = GetComponentsInChildren<SlotItem>(true);
    }

    private void OnEnable()
    {
        GameplayEvents.OnItemPickup += AddToInventory;
        UIEvents.OpenInventory += ManageView;
    }
    private void OnDisable()
    {
        GameplayEvents.OnItemPickup -= AddToInventory;
        UIEvents.OpenInventory -= ManageView;
    }

    private void ManageView()
    {
        if (panel.activeSelf)
            Hide();
        else
            Show();
    }
    private void Show()
    {
        panel.SetActive(true);
    }
    private void Hide()
    {
        panel.SetActive(false);
    }

    private void AddToInventory(ItemData item)
    {
        foreach (SlotItem slotItem in slotItems)
        {
            if (!slotItem.IsOccupied)
            {
                slotItem.SetupItem(item);
                break;
            }
        }
    }
}