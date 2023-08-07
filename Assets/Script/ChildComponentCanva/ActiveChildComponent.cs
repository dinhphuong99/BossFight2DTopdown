using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveChildComponent : MonoBehaviour
{
    [SerializeField] private GameObject [] childComponents;
    [SerializeField] private GameObject GameObject;
    private Life life;
    private PlayerLife playerLife;
    private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        life = GameObject.GetComponent<Life>();
        playerLife = GameObject.GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (life != null)
        {
            currentHealth = life.GetCurrentHealth();
        }
        else if (playerLife != null)
        {
            currentHealth = playerLife.GetCurrentHealth();
        }

        if (currentHealth <= 0 || !GameObject.activeSelf)
        {
            Debug.Log("activeSelf " + GameObject.activeSelf);
            foreach (var component in childComponents)
            {
                component.SetActive(false);
            }
        }
        else
        {
            foreach (var component in childComponents)
            {
                component.SetActive(true);
            }
        }
    }
}
