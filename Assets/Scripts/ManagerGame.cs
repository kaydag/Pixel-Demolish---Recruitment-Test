using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame instance;

    [SerializeField] private List<GameObject> sawPrefabs;
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] public int xp;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("XP: " + xp);
    }

    public void SpawnCoin(Vector3 position)
    {
        Coin coin = coinPrefab.GetComponent<Coin>();
        if (coin != null)
        {
            coin.SpawnCoin(position);
        }
    }
}
