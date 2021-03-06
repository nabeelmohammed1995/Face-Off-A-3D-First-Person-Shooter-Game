﻿using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	
	}
	
	//get movement vector
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    //get rotation
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }
    //get camera rotation
    public void Rotatecamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }
    //run evey iteration
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }
	//performing movement
    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
    //perform rotation
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }
    
	}

