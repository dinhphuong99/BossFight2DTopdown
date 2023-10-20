using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoom : MonoBehaviour
{
    [SerializeField] private GameObject boomPrefab;
    [SerializeField] private GameObject targetObject;

    public void SpawnBoomWithTargetObject()
    {
        Instantiate(boomPrefab, targetObject.transform.position, targetObject.transform.rotation);
    }
}
