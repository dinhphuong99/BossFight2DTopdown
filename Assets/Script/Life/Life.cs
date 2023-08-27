using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected float maxHealth = 100;
    [SerializeField] protected float currentHealth;
    [SerializeField] protected GameObject damageEffect;

    public bool isDead { get; set; }

    // Start is called before the first frame update
    protected void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        this.isDead = false;
        damageEffect.SetActive(false);
    }

    public virtual void TakeDamage(float damage)
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

    private void Die()
    {
        damageEffect.SetActive(false);
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