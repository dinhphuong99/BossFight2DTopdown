using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalGetTagetObject : MonoBehaviour
{
    [SerializeField] private string tagTakeDamage;
    private GameObject target;

    public GameObject getTargetObject()
    {
        return this.target;
    }

    private void Start()
    {
        this.target = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage) && target == null)
        {
            this.target = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage) && target != null)
        {
            this.target = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage) && target == null)
        {
            this.target = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage) && target != null)
        {
            this.target = null;
        }
    }
}
