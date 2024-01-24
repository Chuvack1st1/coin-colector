[System.Serializable]
public class PlayerModel 
{
    private Inventory _inventory;

    private PlayerMovementData _playerMovementData;

    public PlayerMovementData PlayerMovementData => _playerMovementData;

    public PlayerModel(Inventory inventory, PlayerMovmentConfig playerMovmentConfig)
    {
        _inventory = inventory;
        _playerMovementData = new PlayerMovementData(playerMovmentConfig);
    }

    public Inventory Inventory => _inventory; 
}
