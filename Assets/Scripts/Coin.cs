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
        if (transform.localScale.x <= 0.05f)
        {
            Destroy(gameObject);
            if (GameManager.instance != null)
            {
                GameManager.instance.xp += value;
                if (UIManager.instance != null)
                {
                    UIManager.instance.UpdateProgressXp(GameManager.instance.xp, GameManager.instance.xpToUpgrade);
                    UIManager.instance.UpdateProgressLv(GameManager.instance.xp, GameManager.instance.xpToNextLevel);
                }
            }
        }
    }

    public void SpawnCoin(Vector3 position)
    {
        position.y -= 0.75f;
        Instantiate(gameObject, position, Quaternion.identity);
    }
}
