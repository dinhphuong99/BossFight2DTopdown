using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollSkill : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private bool isRoll = false;
    private bool isCooldown = false;
    private float rollTimer = 0f;
    public float rollTime = 3f;
    protected float lastTimeRollTime;
    private float cooldownTimer = 0f;
    public float cooldownTime = 15f;
    protected float lastTimeCooldownTime;
    private bool once;

    public bool GetIsRoll()
    {
        return this.isRoll;
    }

    public float GetCooldownTimer()
    {
        return this.cooldownTimer;
    }

    public bool GetIsCooldown()
    {
        return this.isCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRoll)
        {
            player.GetComponent<PlayerLife>().SetIsmortal(true);
        }
        else
        {
            player.GetComponent<PlayerLife>().SetIsmortal(false);
        }

        if (Input.GetKeyDown(KeyCode.Z) && rollTimer <= 0 && !isCooldown)
        {
            rollTimer = rollTime;
            cooldownTimer = cooldownTime;
            once = true;
            isRoll = true;
            isCooldown = true;
        }

        if (rollTimer <= 0 && once)
        {
            once = false;
            isRoll = false;
        }
        else
        {
            rollTimer -= Time.unscaledDeltaTime;
        }

        if (isCooldown)
        {
            cooldownTimer -= Time.unscaledDeltaTime;

            if (cooldownTimer <= 0)
            {
                isCooldown = false;
            }
        }
    }
}