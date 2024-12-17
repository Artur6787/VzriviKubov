using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 40f;
    [SerializeField] private float _forceExplosion = 100;

    public void Explode()
    {
        float radius = _explosionRadius / transform.transform.localScale.x;
        float force = _forceExplosion / transform.transform.localScale.x;

        foreach (Rigidbody cube in GetCubesRigitbody())
        {
            cube.AddExplosionForce(force, transform.position, radius);
        }
    }

    private List<Rigidbody> GetCubesRigitbody()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);
        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}