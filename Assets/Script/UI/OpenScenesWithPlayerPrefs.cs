using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScenesWithPlayerPrefs : MonoBehaviour
{
    [SerializeField] private string curentScenes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        PlayerPrefs.SetString("currentScenes", "Tutorial");
        PlayerPrefs.Save();
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("currentScenes"));
    }

    public void SetCurrentScenes()
    {
        if(curentScenes != null && curentScenes.Equals(PlayerPrefs.GetString("currentScenes")))
        {
            PlayerPrefs.SetString("currentScenes", curentScenes);
            PlayerPrefs.Save();
        }
        else if(curentScenes == null)
        {
            PlayerPrefs.SetString("currentScenes", "Tutorial");
            PlayerPrefs.Save();
        }
        
    }
}
