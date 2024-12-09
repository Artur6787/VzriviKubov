using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Explosion))]
public class Cube : MonoBehaviour
{
    private float _maximumChance = 100f;
    private float _minimumChance = 0f;
    private Explosion _explosion;

    public event Action<Cube> Exploded;

    public Rigidbody Rigidbody { get; private set; }
    public float ChanceToSplit { get; private set; } = 100f;

    private void Awake()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Rigidbody = GetComponent<Rigidbody>();
        _explosion = GetComponent<Explosion>();
    }

    private void OnMouseUpAsButton()
    {
        TryToSplit();
    }

    public void Initialization(Vector3 scale, float change, Spawner spawner)
    {
        transform.localScale = scale;
        ChanceToSplit = change;
        _explosion.Initialize(spawner);
    }

    private void TryToSplit()
    {
        float chance = Random.Range(_minimumChance, _maximumChance);

        if (chance <= ChanceToSplit)
        {
            Exploded?.Invoke(this);
        }

        Destroy(gameObject);
    }
}