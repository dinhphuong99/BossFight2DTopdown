using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField] private float speedRunaway = 3.5f;
    private Vector3 moveInput = Vector3.zero;
    [SerializeField] private GameObject detechRunaway;
    [SerializeField] private GameObject objectParentChase;
    [SerializeField] private GameObject objectChildChase;
    [SerializeField] private GameObject objectParentRunaway;
    [SerializeField] private GameObject objectChildRunaway;
    [SerializeField] private GameObject objectStartBattle;
    [SerializeField] private GameObject objectBoss;
    [SerializeField] private GameObject vanish;
    private FindVectorRunAway findVectorRunAway;
    private QueueBehavier queueBehavier;
    private Collider2D colliderBoss;
    private AIPath aIPath;
    private Life life;

    // Start is called before the first frame update
    void Start()
    {
        findVectorRunAway = detechRunaway.GetComponent<FindVectorRunAway>();
        aIPath = GetComponent<AIPath>();
        colliderBoss = GetComponent<Collider2D>();
        queueBehavier = GetComponent<QueueBehavier>();
        life = GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life.GetCurrentHealth() <= 0)
        {
            Freeze();
            objectStartBattle.SetActive(false);
            objectBoss.SetActive(false);
            vanish.SetActive(true);
        }
        else
        {
            if (PlayerPrefs.GetInt("startBattle") <= 0)
            {
                objectStartBattle.SetActive(false);
                objectBoss.SetActive(true);
                colliderBoss.enabled = true;
                queueBehavier.enabled = true;
            }
            else
            {
                objectStartBattle.SetActive(true);
                objectBoss.SetActive(false);
                colliderBoss.enabled = false;
                queueBehavier.enabled = false;
            }

            if (!objectParentChase.activeSelf)
            {
                objectChildChase.SetActive(false);
            }

            if (!objectParentRunaway.activeSelf)
            {
                objectChildRunaway.SetActive(false);
            }

            if (objectChildChase.activeSelf)
            {
                Chase();
            }
            else if (objectChildRunaway.activeSelf)
            {
                Runaway();
            }
            else
            {
                Freeze();
            }
        }
    }

    private void Runaway()
    {
        moveInput = findVectorRunAway.moveInput;
        aIPath.enabled = false;
        transform.position += moveInput.normalized * speedRunaway * Time.deltaTime;
    }

    private void Chase()
    {
        moveInput = Vector3.zero;
        aIPath.enabled = true;
    }

    private void Freeze()
    {
        moveInput = Vector3.zero;
        aIPath.enabled = false;
    }
}
