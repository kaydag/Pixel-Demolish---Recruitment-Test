using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField] bool posRotationDirection = true;
    [SerializeField] float rotationSpeed = 20f;
    [SerializeField] float rotationAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        Roating();
    }

    void Roating()
    {
        if (rotationAngle > 360f)
        {
            rotationAngle = 0f;
        }
        rotationAngle += rotationSpeed * Time.deltaTime * (posRotationDirection ? 1 : -1);
        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle);
    }
}
