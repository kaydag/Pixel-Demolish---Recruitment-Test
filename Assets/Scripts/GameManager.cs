using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private List<GameObject> listSawPrefabs;
    [SerializeField] private GameObject sawPrefabs;
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] public int xp = 0;
    [SerializeField] public int xpToNextLevel = 100;
    [SerializeField] private int baseXpToUpgrade = 100;
    [SerializeField] private int xpIncrease = 50;
    [SerializeField] public int xpToUpgrade = 200;
    [SerializeField] private int upgradeCount = 0;

    [SerializeField] public int level = 1;

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
        xpToUpgrade = baseXpToUpgrade + xpIncrease * (upgradeCount - 1);
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
        if (xp >= xpToUpgrade)
        {
            xp -= xpToUpgrade;
            upgradeCount++;
            Debug.Log("Upgrade available! Choose an upgrade.");
            xpToUpgrade = baseXpToUpgrade + xpIncrease * (upgradeCount - 1);
            UIManager.instance.UpdateProgressXp(xp, xpToUpgrade);
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
