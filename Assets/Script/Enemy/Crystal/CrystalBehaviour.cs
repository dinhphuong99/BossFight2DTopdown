using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBehaviour : MonoBehaviour
{
    private DetectionCollider detectionCollider;
    private CrystalGetTagetObject crystalGetTagetObject;
    [SerializeField] private GameObject detech;
    private GameObject targetSend = null;
    [SerializeField] private string tagTakeEnergy;
    [SerializeField] private float energy = 3f;
    [SerializeField] private float speed = 3f;
    private bool isFollow = false;
    private bool isSent = false;

    // Start is called before the first frame update
    void Start()
    {
        detectionCollider = detech.GetComponent<DetectionCollider>();
        crystalGetTagetObject = detech.GetComponent<CrystalGetTagetObject>();
    }

    // Update is called once per frame
    [Obsolete]
    void Update()
    {
        if (detectionCollider.isTouch)
        {
            isFollow = true;
        }

        targetSend = crystalGetTagetObject.getTargetObject();

        if (isFollow && targetSend != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetSend.transform.position, Time.deltaTime * speed);
        }

        if (isSent)
        {
            DestroyObject(this.transform.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagTakeEnergy))
        {
            var playerLife = collision.gameObject.GetComponent<LifeWithRevival>();
            targetSend = collision.gameObject;
            if (playerLife != null)
            {
                playerLife.IncreaseEnergy(energy);
                isSent = true;
            }
        }
    }
}
