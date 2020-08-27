using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSentitive = 100f;
    public Transform player;
    float xRotate = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSentitive;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSentitive;

        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
