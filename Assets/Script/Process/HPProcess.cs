using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPProcess : MonoBehaviour
{
    [SerializeField] private new GameObject gameObject;
    private PlayerLife playerLife;
    private Life life;
    private float currentValue;
    private float maxValue;
    private ProcessBar processBar;

    // Start is called before the first frame update
    void Start()
    {
        playerLife = gameObject.GetComponent<PlayerLife>();
        life = gameObject.GetComponent<Life>();
        if (playerLife != null)
        {
            maxValue = playerLife.GetMaxHealth();
        }
        else if (life != null)
        {
            maxValue = life.GetMaxHealth();
        }
        processBar = GetComponent<ProcessBar>();
    }

    void Update()
    {
        if (playerLife != null)
        {
            currentValue = playerLife.GetCurrentHealth();
        }
        else if (life != null)
        {
            currentValue = life.GetCurrentHealth();
        }

        processBar.UpdateBar(currentValue, maxValue);
    }
}