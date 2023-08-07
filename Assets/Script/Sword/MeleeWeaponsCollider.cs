using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponsCollider : MonoBehaviour
{
    private Collider2D boxCollider;
    private bool isOn = false;

    public bool GetIsOn()
    {
        return this.isOn;
    }
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<PolygonCollider2D>();
    }

    public void SetOnCollider()
    {
        boxCollider.enabled = true;
    }

    public void SetOffCollider()
    {
        boxCollider.enabled = false;
    }

    public void SetStart()
    {
        this.isOn = true;
    }

    public void SetEnd()
    {
        this.isOn = false;
    }
}
