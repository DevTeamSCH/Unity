using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RL.Combat
{  //TODO is this right?

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
                if (fpsCamera != null && tpsCamera != null)
                {
                    if (cameraState == CameraState.FPS)
                    {
                        fpsCamera.SetActive(false);
                        tpsCamera.SetActive(true);
                        cameraState = CameraState.TPS;

                    }
                    else
                    {
                        fpsCamera.SetActive(true);
                        tpsCamera.SetActive(false);
                        cameraState = CameraState.FPS;

                    }
                }

            }
        }
    }
}