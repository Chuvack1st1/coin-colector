using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class LevelSpawnService : MonoBehaviour
{
    public List<Level> levelsPrefabs = new List<Level>();

    public Level currentSpawnedLevel = null;

    public Action<Level> LevelSpawnedEvent = null;

    public void SpawnStartLevel()
    {
        SpawnLevel(0);

    }

    public void SpawnLevel(int levelNumber)
    {
        
        SpawnLevel(levelsPrefabs[levelNumber]);
    }

    private void SpawnLevel(Level level)
    {
        if (level == null)
            return;

        DespawnCurrentLevel();

        var SpawnedLevel = Instantiate(level.gameObject);

        SpawnedLevel.GetComponent<Level>().Init(this);

        currentSpawnedLevel = SpawnedLevel.GetComponent<Level>();

        LevelSpawnedEvent?.Invoke(currentSpawnedLevel);
    }

    private void DespawnCurrentLevel()
    {
        if (currentSpawnedLevel != null)
        {
            Destroy(currentSpawnedLevel.gameObject);
            currentSpawnedLevel = null;
        }
    }
}
