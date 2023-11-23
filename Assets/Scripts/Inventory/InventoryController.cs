using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;

    [SerializeField] private InventoryUI _ui;
    [SerializeField] private List<ItemData> _inventory = new List<ItemData>();
    [SerializeField] private List<ItemData> _itemsConsumidos = new List<ItemData>();
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
                ItemData itemData = _inventory[selectedPos];
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

    public void AddItem(ItemData item)
    {
        item.PickUp();
        _inventory.Add(item);
        _ui?.AddItem(item);
    }

    public void itemSelect(bool next)
    {
        if (next)
        {
            selectedPos++;
            if (selectedPos >= _inventory.Count)
                selectedPos = 0;
        }
        else
        {
            selectedPos--;
            if (selectedPos < 0)
                selectedPos = _inventory.Count - 1;
        }
    }
    
    public bool TratarDeUsarItem(ItemData item, bool consumirItemAlUsar)
    {
        bool tengoElItem = HasItem(item);
        if (tengoElItem && consumirItemAlUsar)
        {
            _itemsConsumidos.Add(item);
            SfxManager.Instance.Play(item.sonidoAlUsar);
            RemoveItem(item);
        }
        return tengoElItem;
    }

    public bool FueConsumido(ItemData item)
    {
        return _itemsConsumidos.Contains(item);
    }

    public bool HasItem(ItemData item)
    {
        return _inventory.Contains(item);
    }

    private void RemoveItem(ItemData item)
    {
        item.Drop();
        _inventory?.Remove(item);
        _ui?.RemoveItem(item);
    }

    public void Reset()
    {
        _inventory.Clear();
        _itemsConsumidos.Clear();
    }
}
