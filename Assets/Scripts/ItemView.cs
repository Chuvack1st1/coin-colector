using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Item item;

    public Item GetItem()
    {
        return item;
    }

    private void SetItem(Item value)
    {
        item = value;
    }
}
