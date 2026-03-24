using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGame : MonoBehaviour
{
    public static ManagerGame instance;

    [SerializeField] private List<GameObject> listSawPrefabs;
    [SerializeField] private GameObject sawPrefabs;
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] public int xp = 0;
    [SerializeField] public int baseXpToUpgrade = 100;
    [SerializeField] public int xpIncrease = 50;
    [SerializeField] public int upgradeCount = 0;;

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
        Upgrade();
    }

    public void SpawnCoin(Vector3 position)
    {
        Coin coin = coinPrefab.GetComponent<Coin>();
        if (coin != null)
        {
            coin.SpawnCoin(position);
        }
    }
    void Upgrade()
    {
        int xpToUpgrade = baseXpToUpgrade + xpIncrease * (upgradeCount - 1);
        if (xp >= xpToUpgrade)
        {
            xp -= xpToUpgrade;
            upgradeCount++;
            Debug.Log("Upgrade available! Choose an upgrade.");
        }
        else return;
    }
    public void ChooseUpgrade(int index)
    {
        switch (index)
        {
            case 1:
                Debug.Log("Upgrade: Size");
                foreach (GameObject sawPrefab in listSawPrefabs)
                {
                    Saw saw = sawPrefab.GetComponent<Saw>();
                    if (saw != null)
                    {
                        saw.IncreaseSize();
                    }
                }
                break;
            case 2:
                Debug.Log("Upgrade: Speed");
                foreach (GameObject sawPrefab in listSawPrefabs)
                {
                    Saw saw = sawPrefab.GetComponent<Saw>();
                    if (saw != null)
                    {
                        saw.IncreaseSpeed();
                    }
                }
                break;
            case 3:
                Debug.Log("Upgrade: Damage");
                foreach (GameObject sawPrefab in listSawPrefabs)
                {
                    Saw saw = sawPrefab.GetComponent<Saw>();
                    if (saw != null)
                    {
                        saw.IncreaseDamage();
                    }
                }
                break;
            case 4:
                Debug.Log("Upgrade: Spawn Saw");
                listSawPrefabs.Add(sawPrefabs);
                break;
            default:
                Debug.Log("Invalid upgrade choice.");
                break;
        }

    }
}
