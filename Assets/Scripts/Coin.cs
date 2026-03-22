using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value = 1;
    [SerializeField] private bool isCollected = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isCollected)
        {
            CollectCoin();
        }   
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            isCollected = true;
        }
    }

    void CollectCoin()
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        if (transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
    }
}
