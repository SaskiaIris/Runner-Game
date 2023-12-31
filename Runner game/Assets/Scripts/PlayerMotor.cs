﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {
	private CharacterController controller;
	private Vector3 moveVector;

	[SerializeField]
	private float speed = 5.0f;
	[SerializeField]
	private float verticalVelocity = 0.0f;
	[SerializeField]
	private float gravity = 9.81f;

	[SerializeField]
	private float animationDuration = 2.0f;

	// Start is called before the first frame update
	void Start() {
		controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
		if(Time.time < animationDuration) {
			controller.Move(Vector3.forward * speed * Time.deltaTime);
			return;
		}

		moveVector = Vector3.zero;

		if(controller.isGrounded) {
			verticalVelocity = -0.5f;
		} else {
			verticalVelocity -= gravity * Time.deltaTime;
		}

		//X = Left/Right
		moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

		//Y = Up/Down
		moveVector.y = verticalVelocity;

		//Z = Forward/Backward
		moveVector.z = speed;

		controller.Move(moveVector * Time.deltaTime);
    }
}