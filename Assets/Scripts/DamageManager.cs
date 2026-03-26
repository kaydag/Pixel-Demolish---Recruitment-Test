using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public float radius = 2f;
    public float maxDamage = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Collider2D[] hits = Physics2D.OverlapCircleAll(worldPos, radius);

        foreach (var hit in hits)
        {
            PixelGroup group = hit.GetComponent<PixelGroup>();

            if (group != null)
            {
                group.DamageAtPoint(worldPos, radius, maxDamage);
            }
        }

    }
}
