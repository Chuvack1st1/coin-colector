
[System.Serializable]
public class Item
{
    public string Name;
    public string Description;
    public Item()
    {
            
    }
    public Item(string name, string description)
    {
        Name = name;
        Description = description;
    }
    public Item(Item itemToAdd)
    {
        Name = itemToAdd.Name;
        Description = itemToAdd.Description;
    }
}
