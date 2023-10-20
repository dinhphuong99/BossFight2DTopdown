using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosttionTargetRunAway : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;// gameObject đầu tiên là chaseObject 
    [SerializeField] private float speed = 10f;
    private float curentDistance = 0f;
    [SerializeField] private float runAwayDistance = 6f;
    [SerializeField] private float chaseDistance = 7f;

    private void Update()
    {
        curentDistance = Vector2.Distance(gameObjects[0].transform.position, transform.position);

        if(curentDistance > chaseDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, gameObjects[0].transform.position, Time.deltaTime * speed);
        }

        if (curentDistance < runAwayDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, gameObjects[1].transform.position, Time.deltaTime * speed);
        }
    }
}
