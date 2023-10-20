using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject chaseObject;
    private EnemyRunAway enemyRunAway;
    private Vector3 moveInput;
    private float moveSpeed = 3.5f;

    private void Start()
    {
        enemyRunAway = GetComponent<EnemyRunAway>();
    }

    void Update()
    {
        moveInput.x = transform.position.x - chaseObject.transform.position.x;
        moveInput.y = transform.position.y - chaseObject.transform.position.y;
        transform.position += moveInput.normalized * moveSpeed * Time.deltaTime;
    }
}
