using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSound : MonoBehaviour
{
    [SerializeField] private AudioSource beforeCombatSound;
    [SerializeField] private AudioSource whileCombatSound;
    private float startCombat = -1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startCombat != PlayerPrefs.GetInt("startBattle"))
        {
            startCombat = PlayerPrefs.GetInt("startBattle");
            if (startCombat > 0)
            {
                beforeCombatSound.Play();
                whileCombatSound.Pause();
            }
            else
            {
                whileCombatSound.Play();
                beforeCombatSound.Pause();
            }
        }
    }
}
