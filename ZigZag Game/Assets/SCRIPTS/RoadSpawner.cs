using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] GameObject lastRoad;
    Vector3 roadDirection;
    public bool stop;

    void Start()
    {
        StartCoroutine(SpawnRoads());
    }

    void CreateRoad()
    {
        if (Random.Range(0, 2) == 0)
        {
            roadDirection = Vector3.left;
        }
        else
        {
            roadDirection = Vector3.forward;
        }
    }

    public IEnumerator SpawnRoads()
    {
        while (!stop)
        {
            CreateRoad();
            lastRoad = Instantiate(lastRoad, lastRoad.transform.position + roadDirection, lastRoad.transform.rotation);
            yield return new WaitForSeconds(1f);
        }
    }

}
