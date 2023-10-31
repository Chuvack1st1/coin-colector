using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

[System.Serializable]
public class Inventory 
{
    private int _maxSize = 10;

    public List<Item> objects = new List<Item>();

    public Action<Item> InventoryHasChangedEvent;

    public bool AddItem(Item itemToAdd)
    {
        if (objects == null)
            objects = new List<Item>();

        if (objects.Count >= _maxSize)
        {
            return false;
        }

        objects.Add(itemToAdd);
        InventoryHasChangedEvent?.Invoke(objects.Find(item => item == itemToAdd));
        return true;
    }

    public bool RemoveItem(Item itemToRemove)
    {
        if (objects == null || objects.Count == 0)
        {
            return false;
        }

        InventoryHasChangedEvent?.Invoke(objects.Find(item => item == itemToRemove));
        objects.Remove(itemToRemove);
        return true;
    }
}
