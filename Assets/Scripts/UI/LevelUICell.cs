using UnityEngine;
using UnityEngine.UI;

public class LevelUICell : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private Button _controllButton;

    public void Init(LevelSpawnService levelSpawnService)
    {
        _controllButton.onClick.AddListener(() => levelSpawnService.SpawnLevel(_levelNumber));
    }
}
