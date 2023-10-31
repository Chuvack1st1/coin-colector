[System.Serializable]
public class Slot
{
    private Item _item;

    public Item Item { get => _item; set => _item = value; }

    public Slot()
    {
        Item = new("","");
    }

    public Slot(Item item)
    {
        Item = new Item(Item.Name, Item.Description);
    }

    public void InitSlot(Slot slot)
    {
        Item = new Item(slot.Item.Name, slot.Item.Description);
    }

    public void ClearSlot()
    {
        Item = null;
    }
}
