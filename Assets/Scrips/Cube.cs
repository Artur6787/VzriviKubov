using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private float _maximumChance = 100f;
    private float _minimumChance = 0f;
    private Explosion _eplosion;

    public event Action<Cube> Exploded;

    public Rigidbody Rigidbody { get; private set; }
    public float ChanceToSplit { get; private set; } = 100f;

    private void Awake()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Rigidbody = GetComponent<Rigidbody>();
        _eplosion = GetComponent<Explosion>();
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

    private void TryToSplit()
    {
        float chance = Random.Range(_minimumChance, _maximumChance);

        if (chance <= ChanceToSplit)
        {
            Exploded?.Invoke(this);
        }
        else
        {
            _eplosion.Explode();
        }

            Destroy(gameObject);
    }
}
//using System;
//using System.Collections.Generic;
//using UnityEngine;
//using Random = UnityEngine.Random;

//[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(Renderer))]
//[RequireComponent(typeof(Explosion))]

//public class Cube1 : MonoBehaviour
//{
//    private float _minChanceToSplit = 0;
//    private float _maxChanceToSplit = 100;
//    private Explosion _eplosion;

//    public event Action<Cube1> Splited;

//    public Rigidbody Rigidbody { get; private set; }
//    public float ChanceToSplit { get; private set; } = 100;

//    private void Awake()
//    {
//        Rigidbody = GetComponent<Rigidbody>();
//        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
//        _eplosion = GetComponent<Explosion>();
//    }

//    private void OnMouseUpAsButton()
//    {
//        TryToSplit();
//    }

//    public void Init(Vector3 scale, float change)
//    {
//        transform.localScale = scale;
//        ChanceToSplit = change;
//    }

//    private void TryToSplit()
//    {
//        float chance = Random.Range(_minChanceToSplit, _maxChanceToSplit);

//        if (chance <= ChanceToSplit)
//        {
//            Splited?.Invoke(this);
//        }
//        else
//        {
//            _eplosion.Explode();
//        }

//        Destroy(gameObject);
//    }
//}