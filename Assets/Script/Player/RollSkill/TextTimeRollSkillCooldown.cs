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

    // Start is called before the first frame update
    void Start()
    {
        valueText = GetComponent<TextMeshProUGUI>();
        valueText.text = ""+ 0;
        rollSkill = gameObject.GetComponent<RollSkill>();
    }

    // Update is called once per frame
    void Update()
    {
        valueText.text = "";
        cooldown = rollSkill.GetCooldownTimer();
        valueText.text = "" + Math.Round(cooldown, 1);
    }
}
