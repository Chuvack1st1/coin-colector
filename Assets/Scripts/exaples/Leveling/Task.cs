using UnityEngine;
using System;

public class Task 
{
    private string _name;
    private string _description;

    private int _totaleCountComplening = 3;
    private int _currentCountComplening = 0;

    public string QuestItemName = "Coin";

    private bool _isCompleted = false;

    public Action TaskCompleteEvent;

    public bool IsCompleted { get => _isCompleted; 
        private set 
        {
            _isCompleted = value;
            TaskCompleteEvent?.Invoke();
        } 
    }

    public void UpdateCurrentCountComplening(int valueToAdd)
    {
        if(valueToAdd <= 0)
        {
            Debug.LogWarning("valueToAdd need to bigger then 0");
            return;
        }

        _currentCountComplening += valueToAdd;
        if (_currentCountComplening == _totaleCountComplening)
            IsCompleted = true;
    }
}
