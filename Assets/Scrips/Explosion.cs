using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 40f;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private float _force = 100;

    private void OnDestroy()
    {
        _spawner.Created -= Explode;
    }

    public void Initialize(Spawner spawner)
    {
        _spawner = spawner;
        _spawner.Created += Explode;
    }

    private void Explode(List<Cube> cubes, Vector3 center)
    {
        foreach (Cube cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(_force, center, _explosionRadius);
        }
    }
}