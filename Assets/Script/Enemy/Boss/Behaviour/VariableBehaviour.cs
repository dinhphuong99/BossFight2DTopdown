using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("startBattle", 1);
        PlayerPrefs.SetInt("runAway", 0);
        PlayerPrefs.SetInt("chase", 0);
        PlayerPrefs.SetInt("bossDie", 0);
        PlayerPrefs.SetInt("castSkill", 0);
        PlayerPrefs.SetString("currentScenes", "Tutorial");
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
