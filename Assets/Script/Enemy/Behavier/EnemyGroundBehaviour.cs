using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.SetActive(body.activeSelf);
    }
}
