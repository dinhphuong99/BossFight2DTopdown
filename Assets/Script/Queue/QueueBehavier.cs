using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueBehavier : MonoBehaviour
{

    //[SerializeField] private List<Tuple<GameObject, float>> listTimeActiveGameObject = new List<Tuple<GameObject, float>>(); 
    [SerializeField] private GameObject[] behaviours;
    [SerializeField] private float[] timeActives;

    private float activeTime = 0f;
    private float activeTimer = 0f;
    [SerializeField] private float delayTime = 0.3f;
    private float delayTimer = 0f;
    private int currentIndex = 0;
    private int maxIndex = 0;


    // Start is called before the first frame update
    [Obsolete]
    void Start()
    {
        if (behaviours.Length == timeActives.Length)
        {
            maxIndex = behaviours.Length - 1;
            delayTimer = delayTime;
            foreach (GameObject obj in behaviours)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("behaviours và timeActives không cùng số lượng phần tử");
        }
    }

    // Update is called once per frame
    void Update()
    {
        delayTimer += Time.unscaledDeltaTime;
        ActiveObject();
        activeTimer += Time.unscaledDeltaTime;
    }

    private void ActiveObject()
    {
        if (delayTimer >= delayTime)
        {
            delayTimer = 0f;
            activeTime = timeActives[currentIndex];
            behaviours[currentIndex].SetActive(true);

            if (activeTimer >= activeTime)
            {
                behaviours[currentIndex].SetActive(false);
                activeTimer = 0f;

                if (currentIndex == maxIndex)
                {
                    currentIndex = 0;
                }
                else
                {
                    currentIndex = currentIndex + 1;
                }
            }
        }
    }
}
