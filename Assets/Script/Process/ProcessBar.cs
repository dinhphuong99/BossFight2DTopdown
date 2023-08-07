using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProcessBar : MonoBehaviour
{
    [SerializeField] private Image fillBar;
    [SerializeField] private TextMeshProUGUI valueText;

    public void UpdateBar(float currentValue, float maxValue)
    {
        fillBar.fillAmount = (float)currentValue / maxValue;
        valueText.text = currentValue.ToString() + " / " + maxValue.ToString();
    }
}
