using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class OpenCloseUIGrope 
{
    public List<GameObject> Grop;

    public void SetGropActiveState(bool newState)
    {
        foreach (GameObject g in Grop)
        {
            g.gameObject.SetActive(newState);
        }
    }
}
