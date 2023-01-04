using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] Transform cameraHolder;
    [SerializeField] float mouseSensitivity = 1;

    float verticalLookRotation;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (TimerManager.instance.checksum() && (!PauseMenu.IsPaused))
        {


            transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);
            verticalLookRotation -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
            cameraHolder.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
        }
    }
}
