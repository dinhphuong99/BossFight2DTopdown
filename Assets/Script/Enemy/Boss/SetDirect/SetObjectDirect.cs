using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectDirect : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private GameObject center;
    [SerializeField] private GameObject up;
    [SerializeField] private GameObject down;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;
    private Vector3 vector3 = Vector3.zero;
    
    private bool castSkill = false;
    void Start()
    {
        //InvokeRepeating(nameof(SetDirect), 0f, 0.25f);
    }

    private void Update()
    {
        if (!castSkill)
        {
            SetDirect();
        }
    }

    public void SetCastSkill( bool castSkill)
    {
        this.castSkill = castSkill;
    }

    private void SetDirect()
    {
        vector3 = targetObject.transform.position - center.transform.position;

        // Đặt giá trị normalized cho direct
        if (Math.Abs(vector3.x) > Math.Abs(vector3.y))
        {
            //Debug.Log("x: " + vector3.x + "y: " + vector3.y);
            //direct = new Vector3(0, vector3.x, 0).normalized;
            if (vector3.x > 0)
            {
                // right
                up.SetActive(false);
                down.SetActive(false);
                left.SetActive(false);
                right.SetActive(true);
            }

            if(vector3.x < 0)
            {
                // left
                up.SetActive(false);
                down.SetActive(false);
                left.SetActive(true);
                right.SetActive(false);
            }
        }
        else
        {
            //direct = new Vector3(0, vector3.y, 0).normalized;
            if (vector3.y > 0)
            {
                // up
                up.SetActive(true);
                down.SetActive(false);
                left.SetActive(false);
                right.SetActive(false);
            }

            if (vector3.y < 0)
            {
                //down
                up.SetActive(false);
                down.SetActive(true);
                left.SetActive(false);
                right.SetActive(false);
            }
        }
    }

    public bool GetCastSkill()
    {
        return this.castSkill;
    }
}
