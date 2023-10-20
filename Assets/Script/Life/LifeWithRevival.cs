using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeWithRevival : Life
{
    private bool canRevival = true;
    [SerializeField] private float maxEnergy = 100;
    private bool immortalAfterRevival = false; //nếu true thì không nhận sát thương
    private bool immortal = false;//nếu true thì không nhận sát thương
    [SerializeField] private float currentEnergy;
    [SerializeField] private float immortalTime = 3.0f;
    private float immortalTimer = 0f;

    public void SetImmortal(bool immortal)
    {
        this.immortal = immortal;
    }

    public bool GetImmortal()
    {
        return this.immortal;
    }

    public bool GetCanRevival()
    {
        return this.canRevival;
    }

    private void Awake()
    {
        currentEnergy = maxEnergy;
    }
    public void Update()
    {
        if (immortalAfterRevival)
        {
            immortalTimer += Time.unscaledDeltaTime;

            if (immortalTimer >= immortalTime)
            {
                immortalTimer = 0f;
                immortalAfterRevival = false;
            }
        }
    }

    public override void TakeDamage(float damage)
    {
        if (!immortal && !immortalAfterRevival)
        {
            currentHealth = currentHealth - damage;
            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                damageEffect.SetActive(true);
                damageEffect.GetComponent<LifeTimeDeactive>().ResetLifeTimer();
            }
        }
    }

    private void Die()
    {
        if (!immortalAfterRevival)
        {
            damageEffect.SetActive(false);
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
        if (currentEnergy <= 0f)
        {
            currentEnergy = 0f;
        }
    }

    public void IncreaseEnergy(float energy)
    {
        currentEnergy = currentEnergy + energy;
        if (currentEnergy >= maxEnergy)
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