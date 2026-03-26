using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour
{
    [SerializeField] private float health = 10f;
    public bool isAlive = true;

    // đổi sang array để giảm GC
    public Pixel[] neighbors = new Pixel[4];

    public PixelGroup group;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // ❗ TẮT physics ban đầu để giảm lag
        if (rb != null)
        {
            rb.simulated = false;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    public void Init(Color color)
    {
        spriteRenderer.color = color;
    }

    public void SetNeighbor(int index, Pixel p)
    {
        neighbors[index] = p;
    }

    public void TakeDamage(float damage)
    {
        if (!isAlive) return;

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isAlive = false;
        spriteRenderer.color = Color.gray;
        if (group != null)
            group.NotifyPixelDied(this);
        Detach();
    }

    public void Detach()
    {
        if (rb != null)
        {
            rb.simulated = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 0.5f;
        }
        for (int i = 0; i < neighbors.Length; i++)
        {
            neighbors[i] = null;
        }
        transform.parent = null;
        if (group != null)
        {
            group.allPixels.Remove(this);
            group = null;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isAlive && collision.gameObject.CompareTag("Gear"))
        {
            GameManager.instance.SpawnCoin(transform.position);
            Destroy(gameObject);
        }
    }
}
