using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private GameObject[] pieces;
    [SerializeField] private float timeDestroy = 2f;
    [SerializeField] private string tagTakeDamage;
    [SerializeField] private bool blockByTerrian = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeDamage))
        {
            this.transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.transform.gameObject.GetComponent<Collider2D>().enabled = false;

            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i].SetActive(true);
            }
            
            Invoke("DestroyBullet", timeDestroy);
        }else

        if (blockByTerrian && collision.gameObject.name == "Terrian")
        {
            this.transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.transform.gameObject.GetComponent<Collider2D>().enabled = false;

            for (int i = 0; i < pieces.Length; i++)
            {
                pieces[i].SetActive(true);
            }

            Invoke("DestroyBullet", timeDestroy);
        }
    }

    [Obsolete]
    private void DestroyBullet()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            pieces[i].SetActive(false);
        }
        DestroyObject(this.transform.gameObject);
    }
}