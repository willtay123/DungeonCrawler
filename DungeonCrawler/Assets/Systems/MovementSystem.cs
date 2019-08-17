using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class MovementSystem : ComponentSystem {
	protected override void OnUpdate() {
		Entities.ForEach((ref Translation translation, ref MovementComponent moveComp) => {
			moveComp.Velocity += moveComp.Acceleration * Time.deltaTime;
			translation.Value.x += moveComp.Velocity.x * Time.deltaTime;
			translation.Value.y += moveComp.Velocity.y * Time.deltaTime;
		});

		Entities.ForEach((ref FrictionComponent frictionComp, ref MovementComponent moveComp) => {
			moveComp.Velocity *= frictionComp.Value;
		});
	}
}
