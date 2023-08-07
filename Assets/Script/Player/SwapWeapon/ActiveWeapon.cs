using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : MonoBehaviour
{
    private bool isAttack = false;

    public bool GetIsAttack()
    {
        return this.isAttack;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) // Nhấn giữ chuột trái
        {
            isAttack = true;
        }
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isAttack = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Nhấn giữ chuột trái
        {
            isAttack = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isAttack = false;
        }
    }
}
