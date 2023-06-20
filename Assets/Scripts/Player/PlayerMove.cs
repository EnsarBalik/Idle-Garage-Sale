using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;
    
    [SerializeField] private Rigidbody rb;
    [SerializeField] private DynamicJoystick joystick;

    [SerializeField] private float moveSpeed;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            //ValueController.instance.ValuesPos();
        }
    }
}