
using System;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public List<Task> tasks = new();

    public Action LevelGoalCompleteEvent;

    public void AddTask(Task taskToAdd)
    {
        if(tasks == null)
            tasks = new List<Task>();

        if (taskToAdd == null)
        {
            Debug.LogWarning("taskToAdd is null");
            return;
        }
        
        taskToAdd.TaskCompleteEvent += UpdateIsLevelGoalCompleted;
        tasks.Add(taskToAdd);
        UpdateIsLevelGoalCompleted();
    }

    public void RemoveTask(Task taskToRemove)
    {
        if(taskToRemove == null)
        {
            Debug.LogWarning("taskToRemove is null");
            return;
        }

        taskToRemove.TaskCompleteEvent -= UpdateIsLevelGoalCompleted;
        tasks.Remove(taskToRemove); 
        UpdateIsLevelGoalCompleted();
    }

    private void UpdateIsLevelGoalCompleted()
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].IsCompleted == false)
            {
                return;
            }
        }
        LevelGoalCompleteEvent?.Invoke();
        Debug.Log("Goal is complete");
    }

    //when quest item has been added to inventory, check which task would compete
    public void CheckCompletingTasks(Item item)
    {
        for(int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].QuestItemName == item.Name)
            {
                tasks[i].UpdateCurrentCountComplening(1);
            }  
        }
    }
}
