using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;

    [SerializeField] private Inventory inventory;
    [SerializeField] private InventoryUI _ui;
    private const KeyCode NEXT_ITEM = KeyCode.E;
    private const KeyCode PREV_ITEM = KeyCode.Q;
    private int selectedPos = -1;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (selectedPos != -1)
            {
                ItemData itemData = inventory.GetItems()[selectedPos];
                Debug.Log(itemData.itemName);
            }
        }
        
        if (Input.GetKeyDown(NEXT_ITEM))
        {
            itemSelect(true);
        }
        else if (Input.GetKeyDown(PREV_ITEM))
        {
            itemSelect(false);
        }
        
    }

    public void AddItem(ItemData itemData)
    {
        inventory?.AddItem(itemData);
        _ui?.AddItem(itemData);
    }

    public void itemSelect(bool next)
    {
        if (next)
        {
            selectedPos++;
            if (selectedPos >= inventory.GetItems().Count)
                selectedPos = 0;
        }
        else
        {
            selectedPos--;
            if (selectedPos < 0)
                selectedPos = inventory.GetItems().Count - 1;
        }
    }
    
    public bool TratarDeUsarItem(ItemData item, bool consumirItemAlUsar)
    {
        bool pudoUsarse = inventory.HasItem(item);
        if (pudoUsarse && consumirItemAlUsar)
        {
            RemoveItem(item);
        }
        return pudoUsarse;
    }

    private void RemoveItem(ItemData item)
    {
        inventory?.RemoveItem(item);
        _ui?.RemoveItem(item);
    }

    public Inventory GetInventory() { return inventory; }
}
