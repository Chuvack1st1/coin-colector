using Cinemachine;
using StarterAssets;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    private Transform _spawnPoint;

    private PlayerModel _model;

    private SpawnControl _spawnControl;

    private CinemachineVirtualCamera _playerCamera;

    public GameObject SpawnedPlayer { get; private set; }

    public Action<PlayerSpawner> PlayerHasSpawnedEvent;

    public CinemachineVirtualCamera PlayerCamera { get => _playerCamera; }

    public void Init(PlayerModel playerModel, Transform spawnPoint)
    {
        SpawnedPlayer = null;

        if (spawnPoint == null)
            Debug.LogWarning("spawnPoint is null");

        _spawnPoint = spawnPoint;

        _model = playerModel;

        EnableInput();
    }

    private void EnableInput()
    {
        _spawnControl = new SpawnControl();
        SpawnControl.SpawnPlayerActions playerSpawnActions = new(_spawnControl);

        playerSpawnActions.Spawn.started += ctx => SpawnPlayer(_playerPrefab);

        _spawnControl.Enable();
    }

    private void SpawnPlayer(GameObject playerPref)
    {
        if (SpawnedPlayer != null) return;

        if(playerPref == null)
        {
            Debug.LogError("Player prefab is not inited");
            return;
        }

        GameObject spawnedPlayer = Instantiate(playerPref, _spawnPoint.position, _spawnPoint.rotation);

        InitPlayerView(spawnedPlayer);

        InitControllerCamera(spawnedPlayer);

        _playerCamera = InitPlayerCamera(spawnedPlayer);

        SpawnedPlayer = spawnedPlayer;

        PlayerHasSpawnedEvent?.Invoke(this);
    }

    private void InitControllerCamera(GameObject spawnedPlayer)
    {
        ThirdPersonController thirdPersonController = spawnedPlayer.GetComponent<ThirdPersonController>();

        if(thirdPersonController == null)
        {
            Debug.LogWarning("ThirdPersonController isnt finded on player");
            return;
        }

        thirdPersonController.Init();
    }

    private void InitPlayerView(GameObject spawnedPlayer)
    {

        PlayerView playerView = spawnedPlayer.GetComponentInChildren<PlayerView>();

        if (playerView == null)
        {
            Debug.LogWarning("PlayerView isnt finded on player");
            return;
        }

        playerView.Init(_model);
    }

    private CinemachineVirtualCamera InitPlayerCamera(GameObject spawnedPlayer)
    {

        CinemachineVirtualCamera playerCamera = spawnedPlayer.GetComponentInChildren<CinemachineVirtualCamera>();

        if (playerCamera == null)
        {
            Debug.LogWarning("playerCamera isnt finded on player");
            return null;
        }
        return playerCamera;
    }
}
