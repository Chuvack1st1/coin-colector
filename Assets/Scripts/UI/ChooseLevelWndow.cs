using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevelWndow : MonoBehaviour
{
    [SerializeField] private Transform _content;

    public void Init(LevelSpawnService levelSpawnService)
    {
        for (int i = 0; i < _content.childCount; i++)
        {
            var levelUIcanvas = _content.GetChild(i).GetComponent<LevelUICell>();
            
            if (levelUIcanvas != null)
            {
                levelUIcanvas.ControllButton.onClick.AddListener(() => Debug.Log("asd"));
                Debug.Log(levelUIcanvas.ControllButton.onClick);
            }

            levelUIcanvas.ControllButton.onClick.AddListener(() => levelSpawnService.SpawnLevel(levelUIcanvas.LevelNumber));
        }
    }
}
