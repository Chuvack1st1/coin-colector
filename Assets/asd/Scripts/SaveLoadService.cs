using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class SaveLoadService : MonoBehaviour
{
    private const string pathToDataFile = "PlayerInventoryData";

    private Inventory _playerInventory;

    private SpawnControl spawnControl;

    public void Init()
    {
        InitControlAction();

        _playerInventory = new Inventory();
    }
    private void InitControlAction()
    {
        spawnControl = new SpawnControl();

        SpawnControl.SaveGameActions saveGameActions = new SpawnControl.SaveGameActions(spawnControl);

        saveGameActions.Save.started += ctx =>  Save();

        spawnControl.Enable();
    }

    private void Save()
    {
        string jsonData = JsonConvert.SerializeObject(_playerInventory);
        string filePath = Path.Combine(Application.persistentDataPath, pathToDataFile);

        File.WriteAllText(filePath, jsonData);
    }

    public Inventory LoadInventory()
    {
        string filePath = Path.Combine(Application.persistentDataPath, pathToDataFile);
        
        if (!File.Exists(filePath))
        {
            Debug.LogWarning("File does not exist: " + filePath);
            return null;
        }
        string jsonData = File.ReadAllText(filePath);

        Inventory loadedData = JsonConvert.DeserializeObject<Inventory>(jsonData);
        _playerInventory = loadedData;
        return loadedData;
    }
}

