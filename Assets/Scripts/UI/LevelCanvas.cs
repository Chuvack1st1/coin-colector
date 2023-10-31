using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCanvas : MonoBehaviour
{
    [SerializeField] private MenuUIOpenClose menuUIOpenClose;
    [SerializeField] private ChooseLevelWndow chooseLevelWndow;

    public void Init(LevelSpawnService levelSpawnService)
    {
        menuUIOpenClose.Init();

        chooseLevelWndow.Init(levelSpawnService);
    }
}
