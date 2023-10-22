using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class LifeTimeDeactive : MonoBehaviour
{
    [SerializeField] private float lifeTime = 8f;
    private float lifeTimer = 0f;

    [Obsolete]
    private void Update()
    {
        if (Time.timeScale != 0f)
        {
            lifeTimer += Time.unscaledDeltaTime;
        }
        if (lifeTimer >= lifeTime)
        {
            this.transform.gameObject.SetActive(false);
        }
    }

    public void ResetLifeTimer()
    {
        lifeTimer = 0f;
    }
}