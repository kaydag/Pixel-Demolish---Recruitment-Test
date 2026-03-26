using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField] private bool posRotationDirection = true;
    [SerializeField] private float speedMove = 150f;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float damage = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = speedMove * (posRotationDirection ? 1 : -1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        PixelGroup group = collision.gameObject.GetComponent<PixelGroup>();

        if (group != null)
        {
            group.DamageAtPoint(transform.position, damage * Time.deltaTime);
        }
    }
}
