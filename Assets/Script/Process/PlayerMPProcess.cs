using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMPProcess : MonoBehaviour
{
    [SerializeField] private new GameObject gameObject;
    private LifeWithRevival playerLife;
    private float currentValue;
    private float maxValue;
    private ProcessBar processBar;

    // Start is called before the first frame update
    void Start()
    {
        playerLife = gameObject.GetComponent<LifeWithRevival>();
        maxValue = playerLife.GetMaxEnergy();
        processBar = GetComponent<ProcessBar>();
    }

    void Update()
    {
        currentValue = playerLife.GetCurrentEnergy();
        processBar.UpdateBar(currentValue, maxValue);
    }
}