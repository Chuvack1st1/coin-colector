using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private SaveLoadService _saveLoadService;
    [SerializeField] private PlayerSpawner _playerspawner;
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private LevelSpawnService _levelSpawnService;

    private void Awake()
    {
        _saveLoadService.Init();

        _cameraManager.Init();

        _levelSpawnService.SpawnStartLevel();

        var loadedInventory = _saveLoadService.LoadInventory();

        _playerspawner.Init(new PlayerModel(loadedInventory));

        _levelSpawnService.LevelSpawnedEvent += _playerspawner.OnSpawnedLevelChanged;
        _levelSpawnService.LevelSpawnedEvent += _playerspawner.SpawnPlayerOnSpawnLevel;

        _playerspawner.PlayerHasSpawnedEvent += _cameraManager.ActivatePlayerCamera;
        _playerspawner.PlayerHasSpawnedEvent += OnPlayerSpawned;
    }

    private void OnPlayerSpawned(PlayerSpawner playerSpawner)
    {
        _playerspawner.SpawnedPlayer.GetComponentInChildren<PlayerView>().PlayerModel.Inventory.InventoryHasChangedEvent += _levelSpawnService.currentSpawnedLevel.Goal.CheckCompletingTasks;
    }
}
