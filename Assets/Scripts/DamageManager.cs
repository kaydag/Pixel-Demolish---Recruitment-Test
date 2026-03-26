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
        TakeDamage();
    }

    void TakeDamage()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] hits = Physics2D.OverlapCircleAll(worldPos, radius);
            foreach (var hit in hits)
            {
                Pixel p = hit.GetComponent<Pixel>();
                if (p != null && p.isAlive)
                {
                    float dist = Vector2.Distance(worldPos, p.transform.position);
                    float dmg = Mathf.Lerp(maxDamage, 0, dist / radius);
                    p.TakeDamage(dmg);
                }
            }
        }
    }
}
