using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CameraState
{
    FPS,
    TPS
};
public class CameraControl : MonoBehaviour
{
    public GameObject fpsCamera;
    public GameObject tpsCamera;
    public CameraState cameraState = CameraState.FPS;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cameraState == CameraState.FPS && tpsCamera != null)
            {
                fpsCamera.SetActive(false);
                tpsCamera.SetActive(true);
                cameraState = CameraState.TPS;
                
            }
            else if (fpsCamera != null)
            {
                fpsCamera.SetActive(true);
                tpsCamera.SetActive(false);
                cameraState = CameraState.FPS;

            }
        }
    }
}
