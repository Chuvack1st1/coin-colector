using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraManager : MonoBehaviour
{
    public List<CinemachineVirtualCamera> virtualCameras;

    public CinemachineVirtualCamera ActiveCamera { get; private set; }

    private int activeCameraIndex = 0;

    public void Init()
    {
        ActiveCamera = null;
        // Make sure the initial camera is enabled, and others are disabled
        for (int i = 0; i < virtualCameras.Count; i++)
        {
            bool activeState = i == activeCameraIndex;
            if (activeState)
            {
                ActiveCamera = virtualCameras[i];
            }
            virtualCameras[i].gameObject.SetActive(activeState);
        }
    }

    public void SwitchActiveCamera(int newIndex)
    {
        ActiveCamera.gameObject.SetActive(false);

        activeCameraIndex = newIndex;

        ActiveCamera = virtualCameras[activeCameraIndex];

        ActiveCamera.gameObject.SetActive(true);
    }

    public void NextCamera()
    {
        SwitchActiveCamera(activeCameraIndex + 1);
    }

    public void PreviousCamera()
    {
        if(activeCameraIndex - 1 >= 0)
        {
            ActiveCamera.gameObject.SetActive(false);

            activeCameraIndex--;

            ActiveCamera = virtualCameras[activeCameraIndex];

            ActiveCamera.gameObject.SetActive(true);
        } 
    }

    public void ActivatePlayerCamera(PlayerSpawner spawner)
    {
        virtualCameras.Add(spawner.PlayerCamera);

        SwitchActiveCamera(1);
    }
}
