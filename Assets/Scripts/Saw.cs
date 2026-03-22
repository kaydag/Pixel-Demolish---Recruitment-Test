using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private bool posRotationDirection = true;
    [SerializeField] private float speedMove = 150f;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float damage = 5f;

    [SerializeField] private float sizeIncreaseAmount = 0.5f;
    [SerializeField] private float speedIncreaseAmount = 0.5f;
    [SerializeField] private float damageIncreaseAmount = 0.5f;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pixel"))
        {
            Pixel pixel = collision.gameObject.GetComponent<Pixel>();
            if (pixel != null)
            {
                pixel.TakeDamage(damage);
            }
        }
    }

    public void SpawnSaw(Vector3 position)
    {
        transform.position = position;
    }

    public void IncreaseSize()
    {
        transform.scale += new Vector3(sizeIncreaseAmount, sizeIncreaseAmount, 0);
    }

    public void IncreaseSpeed()
    {
        speedMove += speedMove * speedIncreaseAmount;
        rb.angularVelocity = speedMove * (posRotationDirection ? 1 : -1);
    }

    public void IncreaseDamage()
    {
        damage += damage * damageIncreaseAmount;
    }
}
