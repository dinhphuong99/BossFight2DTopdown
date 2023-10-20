using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    private GameObject[] objects;
    [SerializeField] private string tagObject;
    private float shortestDistance = 0f;
    private float distance = 0f;
    [SerializeField] private float speed = 12f;
    // Start is called before the first frame update
    void Start()
    {
        objects = GameObject.FindGameObjectsWithTag(tagObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectShortestDistance() != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, FindObjectShortestDistance().transform.position, Time.deltaTime * speed);
        }
        
    }

    private GameObject FindObjectShortestDistance()
    {
        GameObject nearestObject = null;
        shortestDistance = Mathf.Infinity;
        
        foreach (GameObject obj in objects)
        {
            distance = Vector3.Distance(transform.position, obj.transform.position);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestObject = obj;
            }
        }

        if (nearestObject == null)
        {
            Debug.Log("Không tìm thấy đối tượng có tag " + tagObject);
        }

        return nearestObject;
    }
}
