using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBossBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject hpBoss;
    [SerializeField] private GameObject Boss;
    private Life life;

    // Start is called before the first frame update
    void Start()
    {
        life = Boss.GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Boss.activeSelf || life.GetCurrentHealth() <= 0 || PlayerPrefs.GetInt("startBattle") > 0)
        {
            hpBoss.SetActive(false);
            PlayerPrefs.SetInt("startBattle", 1);
            PlayerPrefs.Save();
        }
        else
        {
            hpBoss.SetActive(true);
        }
    }
}
