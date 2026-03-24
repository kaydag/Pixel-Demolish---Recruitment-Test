using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private TextMeshProUGUI lvText;

    [SerializeField] private GameObject progressLv;
    [SerializeField] private Vector3 baseScaleLv;
    [SerializeField] private GameObject progressXp;
    [SerializeField] private Vector3 baseScaleXp;
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
        baseScaleLv = progressLv.transform.localScale;
        baseScaleXp = progressXp.transform.localScale;

        UpdateUI();
        UpdateProgressLv(GameManager.instance.xp, GameManager.instance.xpToNextLevel);
        UpdateProgressXp(GameManager.instance.xp, GameManager.instance.xpToUpgrade);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateUI()
    {
        lvText.text = "Level: " + GameManager.instance.level;
    }

    public void UpdateProgressLv(float progress, float needed)
    {
        float ratio = Mathf.Clamp01(progress / needed);
        Vector3 scale = baseScaleLv;
        scale.x = baseScaleLv.x * ratio;
        progressLv.transform.localScale = scale;
    }

    public void UpdateProgressXp(float progress, float needed)
    {
        float ratio = Mathf.Clamp01(progress / needed);
        Vector3 scale = baseScaleXp;
        scale.x = baseScaleXp.x * ratio;
        progressXp.transform.localScale = scale;
    }
}
