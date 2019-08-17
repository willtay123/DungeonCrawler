using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class InputSystem : ComponentSystem
{
	private float accValX = 10f;
	private float accValY = 10f;

	protected override void OnUpdate() {
		Entities.ForEach((ref InputComponent inputComp, ref MovementComponent moveComp) => {
			if (inputComp.Enabled) {
				Vector2 acceleration = new Vector2(0, 0);
				if (Input.GetKey(KeyCode.W)) {
					acceleration.y += accValY;
				}
				if (Input.GetKey(KeyCode.A)) {
					acceleration.x -= accValX;
				}
				if (Input.GetKey(KeyCode.S)) {
					acceleration.y -= accValY;
				}
				if (Input.GetKey(KeyCode.D)) {
					acceleration.x += accValX;
				}

				moveComp.Acceleration = acceleration;
			}
		});
	}
}
