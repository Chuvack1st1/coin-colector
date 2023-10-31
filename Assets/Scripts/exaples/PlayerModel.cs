[System.Serializable]
public class PlayerModel 
{
    private Inventory _inventory;

    public PlayerModel(Inventory inventory)
    {
        Inventory = inventory;
    }

    public Inventory Inventory { get => _inventory; private set => _inventory = value; }
}
