using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevelWndow : MonoBehaviour
{
    [SerializeField] private List<LevelUICell> levelUICells = new List<LevelUICell>();

    public void Init(LevelSpawnService levelSpawnService)
    {
        for (int i = 0; i < levelUICells.Count; i++)
        {
            levelUICells[i].Init(levelSpawnService);
        }
    }
}
