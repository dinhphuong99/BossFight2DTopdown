using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private static bool pause = false;
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private GameObject ortherCanvas;
    [SerializeField] private GameObject objectSetDeath;
    [SerializeField] private GameObject objectSetVictory;
    [SerializeField] private GameObject resume;
    [SerializeField] private TextMeshProUGUI statusText;
    private string flag = "";
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        flag = "";
        if (objectSetDeath != null && !objectSetDeath.activeSelf)
        {
            flag = "death";
            DeathOrVictoryStop();
        } else if (objectSetVictory != null && !objectSetVictory.activeSelf)
        {
            flag = "victory";
            DeathOrVictoryStop();
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

    public void DeathOrVictoryStop()
    {
        if (flag.Equals("death"))
        {
            statusText.text = "Death";
            pauseMenuCanvas.SetActive(true);
            if (ortherCanvas != null)
            {
                ortherCanvas.SetActive(false);
            }

            if (resume != null)
            {
                resume.SetActive(false);
            }
            Time.timeScale = 0f;
        }else if (flag.Equals("victory"))
        {
            statusText.text = "Victory";
            pauseMenuCanvas.SetActive(true);
            if (ortherCanvas != null)
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
}
