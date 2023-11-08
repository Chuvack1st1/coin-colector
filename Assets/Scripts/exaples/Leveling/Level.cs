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

        InitLevelQuestCountView(levelCanvas);
    }
    public void InitLevelQuestCountView(LevelCanvas levelCanvas)
    {
        var questViews = levelCanvas.GetComponentsInChildren<QuestItemScoreVIew>();

        foreach(var questView in questViews)
        {
            if (questView != null)
            {
                foreach (var task in goal.tasks)
                {
                    if(task.QuestItemName == questView.questItem.Name)
                    {
                        task.UpdateCurrentScoreCountEvent += questView.OnUpdatedCurrentScoreCount;
                    }
                }
            }
        }
    }
}
