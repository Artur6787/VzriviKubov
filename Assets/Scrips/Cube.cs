using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private float _maximumChance = 100f;
    private float _minimumChance = 0f;
    private Exploder _eplosion;

    public event Action<Cube> Split;

    public Rigidbody Rigidbody { get; private set; }
    public float ChanceToSplit { get; private set; } = 100f;

    private void Awake()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Rigidbody = GetComponent<Rigidbody>();
        _eplosion = GetComponent<Exploder>();
    }

    private void OnMouseUpAsButton()
    {
        TryToSplit();
    }

    public void Configure(Vector3 scale, float change)
    {
        transform.localScale = scale;
        ChanceToSplit = change;
    }

    public void TriggerExplosion()
    {
        _eplosion.Explode();
    }

    private void TryToSplit()
    {
        float chance = Random.Range(_minimumChance, _maximumChance);

        if (chance <= ChanceToSplit)
        {
            Split?.Invoke(this);
        }
        else
        {
            _eplosion.Explode();
        }

        Destroy(gameObject);
    }
}