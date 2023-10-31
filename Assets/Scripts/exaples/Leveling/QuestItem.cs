using UnityEngine;

[System.Serializable]
public class QuestItem : Item
{
    public QuestItem(string name, string description, int questProgressValue) : base(name, description)
    {
        _questProgressValue = questProgressValue;
    }

    [SerializeField] private int _questProgressValue;

    public int QuestProgressValue { get => _questProgressValue; }
}
