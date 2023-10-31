using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerModel playerModel;

    public PlayerModel PlayerModel { get => playerModel; private set => playerModel = value; }

    public void Init(PlayerModel playerModel)
    {
        PlayerModel = playerModel;
    }
}
