using System;
using Unity.Entities;
using UnityEngine;

public struct CubeSpawner : IComponentData
{
    public Entity Cube;
}

[DisallowMultipleComponent]
public class CubeSpawnerAuthoring : MonoBehaviour
{
    public GameObject Cube;

    private class Baker : Baker<CubeSpawnerAuthoring>
    {
        public override void Bake(CubeSpawnerAuthoring authoring)
        {
            var component = default(CubeSpawner);

            component.Cube = GetEntity(authoring.Cube, TransformUsageFlags.Dynamic);

            var entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, component);
        }
    }
}
