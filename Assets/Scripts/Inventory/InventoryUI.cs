using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [Header("Settings")]
    [SerializeField] private InventoryItemUI _itemUiPrefab;
    [SerializeField] private RectTransform _itemContainer;
    
    [Header("Debug")]
    [SerializeField] private List<InventoryItemUI> _items = new List<InventoryItemUI>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(ItemData item)
    {
        if (item == null ||
            _itemUiPrefab == null)
        {
            return;
        }
        InventoryItemUI nuevoIconoItem = Instantiate<InventoryItemUI>(_itemUiPrefab);
        nuevoIconoItem.transform.SetParent(_itemContainer);
        nuevoIconoItem.transform.localScale = Vector3.one;

        nuevoIconoItem.ActualizarIcono(item);

        _items.Add(nuevoIconoItem);
    }
}
