using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private CharacterController cc;
    public float moveSpeed = 10f;
    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        cc.Move(move * moveSpeed * Time.deltaTime);
      
    }   
}