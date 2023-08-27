using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TextTimeRollSkillCooldown : MonoBehaviour
{
    private TextMeshProUGUI valueText;
    private RollSkill rollSkill;
    [SerializeField] private new GameObject gameObject;
    private float cooldown = 0f;
    private string text = ": " + 0;

    // Start is called before the first frame update
    void Start()
    {
        valueText = GetComponent<TextMeshProUGUI>();
        rollSkill = gameObject.GetComponent<RollSkill>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown = rollSkill.GetCooldownTimer();
        if(cooldown >= 10f)
        {
            text = ": ";
        }
        else
        {
            text = ": 0";
        }
        valueText.text = text + Math.Round(cooldown, 1);
    }
}
