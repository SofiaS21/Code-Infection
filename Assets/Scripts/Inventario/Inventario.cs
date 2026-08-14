using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public ItemData[] items; 
    public SlotUI[] slotsUI;

    public static Inventario instancia;
    

     void Awake()
    {
        instancia = this;
    }

    public bool AgregarItem(ItemData nuevoItem)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = nuevoItem;
                slotsUI[i].ActualizarSlot(nuevoItem);
                return true;
            }
        }
        return false; 
    }

    public void QuitarItem(int index)
    {
        items[index] = null;
        slotsUI[index].LimpiarSlot();
    }
}
