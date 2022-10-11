using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public static class Cameraswitcher 
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();
    static CinemachineVirtualCamera Activecamera = null;



    public static bool IsActiveCamera(CinemachineVirtualCamera camera)
    {
        return camera == Activecamera;
    }

    public static void SwitchCamera(CinemachineVirtualCamera camera)
    {
        camera.Priority = 10;
            Activecamera = camera;
        foreach(CinemachineVirtualCamera c in cameras)
        {
            if (c != camera)
            {
                c.Priority = 0;
            }
        }
    }


    public static void Register (CinemachineVirtualCamera camera)
    {
        cameras.Add(camera);
    }
    public static void Unregister(CinemachineVirtualCamera camera)
    {
        cameras.Remove(camera);
    }
}
