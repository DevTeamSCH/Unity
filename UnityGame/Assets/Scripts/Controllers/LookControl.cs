using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RL.Managers
{

    public class LookControl : MonoBehaviour
    {
        // Start is called before the first frame update
        public float mouseSensitivity = 100;
        public Transform playerBody;

        float xRotation;
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 45);


            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}