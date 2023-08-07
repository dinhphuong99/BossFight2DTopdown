﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected TimeDeltaTime timeDelta;
    protected TimerRealTime timerReal;
    [SerializeField] protected float maxHealth = 100;
    [SerializeField] protected float currentHealth;
    protected bool isInvulnerable = false;
    [SerializeField] protected GameObject objectTakeDamage;
    protected bool isImortal = false;

    public bool GetIsmortal()
    {
        return this.isImortal;
    }

    public void SetIsmortal(bool isImortal)
    {
        this.isImortal = isImortal;
    }
    public bool isDead { get; set; }

    // Start is called before the first frame update
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        isInvulnerable = false;
        this.isDead = false;
        timeDelta = GetComponent<TimeDeltaTime>();
        timeDelta.isRun = false;
        timeDelta.time = 0.25f;

        timerReal = GetComponent<TimerRealTime>();
        timerReal.isRun = false;
        timerReal.time = 4f;
    }

    private void Update()
    {
        isInvulnerable = timeDelta.isRun;

        if (isInvulnerable || isImortal)
        {
            if (!objectTakeDamage.activeSelf)
            {
                objectTakeDamage.SetActive(true);
            }
        }
        else
        {
            objectTakeDamage.SetActive(false);
        }
    }

    public void TakeDamage(float damage)
    {
        if (!isInvulnerable && !isImortal)
        {
            currentHealth = currentHealth - damage;
            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                timeDelta.isRun = true;
                timerReal.isRun = true;
            }
        }
    }

    private void Die()
    {
        objectTakeDamage.SetActive(false);
        rb.bodyType = RigidbodyType2D.Static;
        this.isDead = true;
        Invoke("Disable", 0.5f);
    }

    public float GetCurrentHealth()
    {
        return this.currentHealth;
    }

    public float GetMaxHealth()
    {
        return this.maxHealth;
    }

    private void Disable()
    {
        this.gameObject.SetActive(false);
        this.currentHealth = this.maxHealth;
        this.isDead = false;
    }
}