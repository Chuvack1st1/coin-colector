using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private Goal goal = new();

    public Transform SpawnPoint;

    public Goal Goal { get => goal; }

    public void Init(LevelSpawnService levelSpawnService)
    {
        goal.AddTask(new Task());
        InitLevelCanvas(levelSpawnService);
    }
    private void InitLevelCanvas(LevelSpawnService levelSpawnService)
    {
        var levelCanvas = GetComponentInChildren<LevelCanvas>();

        if (levelCanvas == null)
        {
            Debug.Log("Level canvas isnt finded");
            return;
        }

        levelCanvas.Init(levelSpawnService);
    }
}
