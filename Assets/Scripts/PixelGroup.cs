using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelGroup : MonoBehaviour
{
    public List<Pixel> allPixels = new List<Pixel>();
    public int threshold = 3;

    private bool isDirty = false;

    private Rigidbody2D rb;
    private BoxCollider2D col;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0.5f;

        col = GetComponent<BoxCollider2D>();
        if (col == null)
            col = gameObject.AddComponent<BoxCollider2D>();

        FitColliderToPixels();
    }

    public void RegisterPixel(Pixel p)
    {
        allPixels.Add(p);
        p.group = this;
    }

    public void NotifyPixelDied(Pixel p)
    {
        isDirty = true;
    }

    void LateUpdate()
    {
        if (isDirty)
        {
            isDirty = false;
            RecalculateGroups();
        }
    }

    void RecalculateGroups()
    {
        allPixels.RemoveAll(p => p == null || !p.isAlive);
        HashSet<Pixel> visited = new HashSet<Pixel>();
        foreach (Pixel p in allPixels)
        {
            if (!p.isAlive || visited.Contains(p)) continue;
            List<Pixel> group = BFS(p, visited);
            if (group.Count < threshold)
            {
                foreach (var px in group)
                {
                    px.Detach();
                }
            }
        }
    }

    List<Pixel> BFS(Pixel start, HashSet<Pixel> visited)
    {
        Queue<Pixel> queue = new Queue<Pixel>();
        List<Pixel> result = new List<Pixel>();
        queue.Enqueue(start);
        visited.Add(start);
        while (queue.Count > 0)
        {
            Pixel current = queue.Dequeue();
            result.Add(current);
            foreach (Pixel neighbor in current.neighbors)
            {
                if (neighbor != null && neighbor.isAlive && !visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
        return result;
    }

    public void FitColliderToPixels()
    {
        if (col == null)
            col = GetComponent<BoxCollider2D>();
        Bounds bounds = new Bounds();
        bool hasInit = false;
        foreach (Transform child in transform)
        {
            if (!hasInit)
            {
                bounds = new Bounds(child.position, Vector3.zero);
                hasInit = true;
            }
            else
            {
                bounds.Encapsulate(child.position);
            }
        }
        col.offset = bounds.center - transform.position;
        col.size = bounds.size;
        Debug.Log("Collider size: " + col.size);
    }

    public void TakeDamage(Vector2 point, float damage)
    {
        for (int i = allPixels.Count - 1; i >= 0; i--)
        {
            var pixel = allPixels[i];
            if (!pixel.isAlive) continue;
            float dist = Vector2.Distance(pixel.transform.position, point);
            if (dist < 0.5f)
            {
                pixel.TakeDamage(damage);
            }
        }
    }
    public void DamageAtPoint(Vector2 point, float radius, float maxDamage)
    {
        for (int i = allPixels.Count - 1; i >= 0; i--)
        {
            var pixel = allPixels[i];

            if (!pixel.isAlive) continue;

            float dist = Vector2.Distance(point, pixel.transform.position);

            if (dist > radius) continue;

            float t = dist / radius;
            float dmg = Mathf.Lerp(maxDamage, 0, t);

            pixel.TakeDamage(dmg);
        }
    }
}
