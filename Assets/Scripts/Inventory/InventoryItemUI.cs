using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] private Image _icono;
    [SerializeField] private ItemData _item;

    private void Start()
    {
        if (_icono == null)
        {
            _icono = GetComponent<Image>();
        }
    }

    public void ActualizarIcono(ItemData item)
    {
        _item = item;
        _icono.sprite = item.sprite;
    }
}
