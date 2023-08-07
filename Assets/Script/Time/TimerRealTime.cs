using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerRealTime : MonoBehaviour
{
    [SerializeField] public float time { get; set; }
    private float timer = 0f;
    private float lastTime;
    public bool isRun { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        isRun = false;
        time = 0f;
    }

    private void Update()
    {
        if (isRun)
        {
            float currentTime = Time.realtimeSinceStartup;
            float elapsedTime = currentTime - lastTime;
            lastTime = currentTime;

            timer += elapsedTime;
            if (timer >= time)
            {
                isRun = false;
                timer = 0f;
            }
        }
    }

    public void SetRun()
    {
        isRun = true;
    }
}
