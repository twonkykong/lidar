using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollSpawnerTrigger : MonoBehaviour
{
    [SerializeField] private DollSpawner dollSpawner;

    private void Start()
    {
        dollSpawner.AddTrigger(gameObject);
    }

    /*[SerializeField] private Collider collider;
    [SerializeField] private Transform player;
    private Bounds _bounds;

    private void Awake()
    {
        _bounds = collider.bounds;
    }

    private void Update()
    {
        if (_bounds.Contains(player.position))
        {
            dollSpawner.PassTrigger(gameObject);
            Destroy(gameObject);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            dollSpawner.PassTrigger(gameObject);
            Destroy(gameObject);
        }
    }
}
