using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSound : MonoBehaviour
{
    [SerializeField] private AudioSource beforeCombatSound;
    [SerializeField] private AudioSource whileCombatSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("startBattle") <= 0)
        {
            whileCombatSound.Play();
            beforeCombatSound.Pause();
        }
        else
        {
            beforeCombatSound.Play();
            whileCombatSound.Pause();
        }
    }
}
