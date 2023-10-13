using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private IconoItemInventario _itemUiPrefab;
    [SerializeField] private RectTransform _contenedorDeIconos;
    
    [Header("Debug")]
    [SerializeField] private List<IconoItemInventario> _iconos = new List<IconoItemInventario>();

    public void AddItem(ItemData item)
    {
        if (item == null ||
            _itemUiPrefab == null)
        {
            return;
        }
        IconoItemInventario nuevoIconoItem = Instantiate<IconoItemInventario>(_itemUiPrefab);
        nuevoIconoItem.transform.SetParent(_contenedorDeIconos);
        nuevoIconoItem.transform.localScale = Vector3.one;

        nuevoIconoItem.ActualizarIcono(item);

        _iconos.Add(nuevoIconoItem);
    }

    public void RemoveItem(ItemData item)
    {
        foreach (IconoItemInventario icono in _iconos)
        {
            if (icono.Data() != item)
            {
                continue;
            }
            _iconos.Remove(icono);
            Destroy(icono.gameObject);
            return;
        }
    }
}