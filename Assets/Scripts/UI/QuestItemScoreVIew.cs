using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestItemScoreVIew : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextMeshProUGUI;

    private int currentScoreCount = 0;

    public QuestItem questItem;
    public int CurrentScoreCount { get => currentScoreCount; private set => currentScoreCount = value; }

    public  void OnUpdatedCurrentScoreCount(int newValue)
    {
        CurrentScoreCount = newValue;
        TextMeshProUGUI.text = "x" + CurrentScoreCount.ToString();
    }
} 
