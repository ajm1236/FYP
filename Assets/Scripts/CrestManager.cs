using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrestManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform[] crests;
    public Transform[] locations;

    public Transform GetRandomPrefab()
    {
        return crests[Random.Range(0, crests.Length - 1)];
    }
    void Start()
    {


        GetRandomPrefab().transform.position = locations[0].transform.position;
        GetRandomPrefab().transform.position = locations[1].transform.position;

    }

}
