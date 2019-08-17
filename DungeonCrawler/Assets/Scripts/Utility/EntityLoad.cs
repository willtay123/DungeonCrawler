using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Collections;

public class EntityLoad : MonoBehaviour
{
	[SerializeField] private Mesh playerMesh;
	[SerializeField] private Material playerMaterial;

	// Start is called before the first frame update
	void Start()
	{
		EntityManager entityManager = World.Active.EntityManager;

		


		CreatePlayers(entityManager, 1);
	}

	private void CreatePlayers(EntityManager entityManager, int amount) {

		EntityArchetype player = entityManager.CreateArchetype(
			typeof(Translation),
			typeof(RenderMesh),
			typeof(LocalToWorld),
			typeof(MovementComponent),
			typeof(InputComponent),
			typeof(FrictionComponent)
		);

		using (NativeArray<Entity> playerArray = new NativeArray<Entity>(amount, Allocator.Temp)) {
			entityManager.CreateEntity(player, playerArray);

			for (int i = 0; i < playerArray.Length; i++) {
				Entity entity = playerArray[i];

				entityManager.SetSharedComponentData(entity, new RenderMesh {
					mesh = playerMesh,
					material = playerMaterial
				});
				entityManager.SetComponentData(entity, new InputComponent {
					Enabled = true
				});
				entityManager.SetComponentData(entity, new FrictionComponent {
					Value = 0.98f
				});
			}
		}
	}
}
