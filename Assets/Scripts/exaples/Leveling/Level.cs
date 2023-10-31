using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private Goal goal = new();

    public Transform SpawnPoint;

    public Goal Goal { get => goal; }

    public void Init()
    {
        goal.AddTask(new Task());
    }
}
