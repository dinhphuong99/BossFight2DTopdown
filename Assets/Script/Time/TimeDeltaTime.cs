using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDeltaTime : MonoBehaviour
{
    [SerializeField] public float time { get; set; }
    private float timer = 0f;
    public bool isRun { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        isRun = false;
    }

    private void Update()
    {
        if (isRun)
        {
            timer += Time.deltaTime;
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
