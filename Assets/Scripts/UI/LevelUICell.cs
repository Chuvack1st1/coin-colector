using UnityEngine;
using UnityEngine.UI;

public class LevelUICell : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    private Button _controllButton;
    private LevelSpawnService _levelSpawnService;

    public void Init(LevelSpawnService levelSpawnService)
    {
        _controllButton = GetComponent<Button>();
        _levelSpawnService = levelSpawnService;
        Debug.Log("qwe");
        _controllButton.onClick.AddListener(() => _levelSpawnService.SpawnLevel(_levelNumber));
        _controllButton.onClick.AddListener(() => Debug.Log(_levelSpawnService));
    }
}
