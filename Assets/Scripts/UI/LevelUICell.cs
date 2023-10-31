using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUICell : MonoBehaviour
{
    [SerializeField] private int _levelNumber;

    public int LevelNumber => _levelNumber;

    [SerializeField] private Button _controllButton;
    public Button ControllButton => _controllButton;
}
