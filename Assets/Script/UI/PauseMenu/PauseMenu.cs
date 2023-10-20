using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private static bool pause = false;
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private GameObject ortherCanvas;
    [SerializeField] private GameObject objectSetDeath;
    [SerializeField] private GameObject resume;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (objectSetDeath != null && !objectSetDeath.activeSelf)
        {
            DeathStop();
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    public void Play()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }

    public void Stop()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void DeathStop()
    {
        pauseMenuCanvas.SetActive(true);
        if(ortherCanvas != null)
        {
            ortherCanvas.SetActive(false);
        }

        if (resume != null)
        {
            resume.SetActive(false);
        }
        Time.timeScale = 0f;
    }
}
