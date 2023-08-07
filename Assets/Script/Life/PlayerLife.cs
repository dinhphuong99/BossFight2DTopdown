using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : Life
{
    private bool canRevival = true;
    [SerializeField] private float maxEnergy = 100;
    private bool immortalAfterRevival = false;
    private float currentEnergy;

    public bool GetCanRevival()
    {
        return this.canRevival;
    }

    private void Awake()
    {
        currentEnergy = maxEnergy;
    }
    private void Update()
    {
        immortalAfterRevival = timerReal.isRun;
        isInvulnerable = timeDelta.isRun;

        if (isInvulnerable)
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

        if (immortalAfterRevival)
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

    private void Die()
    {
        if (!isInvulnerable && !immortalAfterRevival)
        {
            objectTakeDamage.SetActive(false);
            rb.bodyType = RigidbodyType2D.Static;
            this.isDead = true;
            Invoke("Disable", 0.5f);
        }
    }

    private void Disable()
    {
        this.transform.gameObject.SetActive(false);
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
        isDead = false;
    }

    public float GetCurrentEnergy()
    {
        return this.currentEnergy;
    }

    public float GetMaxEnergy()
    {
        return this.maxEnergy;
    }

    public void ReduceEnergy(float energy)
    {
        currentEnergy = currentEnergy - energy;
        if(currentEnergy <= 0f)
        {
            currentEnergy = 0f;
        }
    }

    public void IncreaseEnergy(float energy)
    {
        currentEnergy = currentEnergy + energy;
        if(currentEnergy >= maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
    }

    public void Revival()
    {
        if (canRevival)
        {
            currentEnergy = maxEnergy;
            currentHealth = maxHealth;
            immortalAfterRevival = true;
            canRevival = false;
        }
    }
}