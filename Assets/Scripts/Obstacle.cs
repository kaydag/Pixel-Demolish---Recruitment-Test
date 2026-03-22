using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obtacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector3 PositionObstacle()
    {
        return transform.position;
    }

    public void SpawnObstacle(Vector3 position)
    {
        transform.position = position;
    }
}

