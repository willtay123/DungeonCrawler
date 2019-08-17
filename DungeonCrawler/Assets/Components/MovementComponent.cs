using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct MovementComponent : IComponentData
{
    public Vector2 Acceleration;
    public Vector2 Velocity;
    public float maxSpeed;
}
