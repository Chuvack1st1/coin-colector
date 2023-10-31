using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class LevelSpawnService : MonoBehaviour
{
    public List<Level> levelsPrefabs = new List<Level>();

    public Level currentSpawnedLevel = null;

    public void SpawnStartLevel()
    {
        SpawnLevel(0);

        InitLevelCanvas();
    }

    public void SpawnLevel(int levelNumber)
    {
        Debug.Log("qwe");
        SpawnLevel(levelsPrefabs[levelNumber]);
    }

    private void SpawnLevel(Level level)
    {
        if (level == null)
            return;

        DespawnCurrentLevel();

        level.Init();

        var SpawnedLevel = Instantiate(level.gameObject);

        currentSpawnedLevel = level.GetComponent<Level>();
    }

    private void InitLevelCanvas()
    {
        var levelCanvas = currentSpawnedLevel.GetComponentInChildren<LevelCanvas>();

        if (levelCanvas == null)
        {
            Debug.Log("Level canvas isnt finded");
            return;
        }

        levelCanvas.Init(this);
    }
    private void DespawnCurrentLevel()
    {
        if (currentSpawnedLevel != null)
        {
            Destroy(currentSpawnedLevel);
        }
    }
}
