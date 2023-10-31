using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIOpenClose : MonoBehaviour
{
    [SerializeField] private List<OpenCloseUIGrope> gropes;

    private int _currentGropNumber = 0;

    public void Init()
    {
        OpenNewGrop(0);
    }

    public void OpenNewGrop(int newGropNumber)
    {
        for (int i = 0; i < gropes.Count; i++)
        {
            var newStateValue = i == newGropNumber;

            gropes[i].SetGropActiveState(newStateValue);
        }
        _currentGropNumber = newGropNumber;
    }
}
