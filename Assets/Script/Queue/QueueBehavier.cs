using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueBehavier : MonoBehaviour
{
    [SerializeField] private GameObject[] behaviours;
    [SerializeField] private float[] timeActives;

    private float activeTime = 0f;
    private float activeTimer = 0f;
    [SerializeField] private float delayTime = 0f;
    private float delayTimer = 0f;
    private int currentIndex = 0;
    private int maxIndex = 0;

    [SerializeField] private GameObject objectReset;
    private bool objectResetActiveLastFrame = false; // Biến cờ theo dõi trạng thái của objectReset
    private bool objectResetDeclared = false; // Biến cờ để kiểm tra xem objectReset đã được khai báo hay chưa

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

        // Kiểm tra xem objectReset đã được khai báo hay chưa
        if (objectReset != null)
        {
            objectResetDeclared = true;
        }
    }

    // Update is called once per frame
    [Obsolete]
    void Update()
    {
        // Kiểm tra trạng thái của objectReset
        bool isObjectResetActive = objectResetDeclared && objectReset != null && objectReset.activeSelf;

        // Nếu objectReset trở thành active từ trạng thái không active trong frame trước đó
        if (isObjectResetActive && !objectResetActiveLastFrame)
        {
            ResetQueue();
        }

        objectResetActiveLastFrame = isObjectResetActive;

        delayTimer += Time.unscaledDeltaTime;
        ActiveObject();
        activeTimer += Time.unscaledDeltaTime;
    }

    [Obsolete]
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

    [Obsolete]
    private void ResetQueue()
    {
        foreach (GameObject obj in behaviours)
        {
            obj.SetActive(false);
        }
        activeTime = 0f;
        delayTimer = 0f;
        currentIndex = 0;
    }
}