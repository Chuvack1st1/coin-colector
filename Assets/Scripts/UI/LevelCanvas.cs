using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCanvas : MonoBehaviour
{
    [SerializeField] private MenuUIOpenClose menuUIOpenClose;
    [SerializeField] private ChooseLevelWndow chooseLevelWndow;

    public void Init(LevelSpawnService levelSpawnService)
    {
        if(chooseLevelWndow != null)
        {
            chooseLevelWndow.Init(levelSpawnService);
        }
        else
        {
            Debug.Log("chooseLevelWndow isnt init in the inspector");
        }
        menuUIOpenClose.Init();
    }
}
