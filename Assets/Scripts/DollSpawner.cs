using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollSpawner : MonoBehaviour
{
    private List<GameObject> _requiredTriggers = new List<GameObject>();
    [SerializeField] private float requiredTime;
    [SerializeField] private bool countTimeAfterTriggers;
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private GameObject doll;
    [SerializeField] private Transform player;

    private bool _timePassed;
    private bool _triggersPassed;

    private void Awake()
    {
        if (!countTimeAfterTriggers) StartCoroutine(TimerCountdown());
    }

    public void PassTrigger(GameObject obj)
    {
        _requiredTriggers.Remove(obj);
        if (_requiredTriggers.Count == 0)
        {
            _triggersPassed = true;
            if (_timePassed) ActivateDoll();
            else if (countTimeAfterTriggers) StartCoroutine(TimerCountdown());
        }
    }

    private IEnumerator TimerCountdown()
    {
        yield return new WaitForSeconds(requiredTime);
        _timePassed = true;
        if (_triggersPassed) ActivateDoll();
    }

    public void AddTrigger(GameObject newTrigger)
    {
        _requiredTriggers.Add(newTrigger);
    }

    public void ActivateDoll()
    {
        if (!doll.activeInHierarchy) doll.SetActive(true);
        Vector3 farthestPoint = player.position;
        float farthestDistance = 0;

        foreach (Transform spawnPoint in spawnPoints)
        {
            float distance = Vector3.Distance(spawnPoint.position, player.position);
            if (distance > farthestDistance)
            {
                farthestPoint = spawnPoint.position;
                farthestDistance = distance;
            }
        }

        doll.transform.position = farthestPoint;
    }
}
