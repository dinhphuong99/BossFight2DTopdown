using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveRecoverAndSetPosition : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private Transform[] positions;
    [SerializeField] private float healthRegen = 100f;
    private bool isSet = false;

    void Update()
    {
        if (isSet)
        {
            for(int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                gameObjects[i].GetComponent<Life>().IncreaseHealth(healthRegen);
                if (!gameObjects[i].activeSelf)
                {
                    gameObjects[i].transform.position = positions[i].position;
                }
                gameObjects[i].SetActive(true);
            }

            isSet = false;
        }
    }

    public void SetTrueIsSet()
    {
        this.isSet = true;
    }
}
