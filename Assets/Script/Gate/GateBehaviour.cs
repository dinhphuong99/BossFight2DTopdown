using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
    private OpenNewScene openNewScene;
    [SerializeField] private string tagActive;

    // Start is called before the first frame update
    void Start()
    {
        openNewScene = GetComponent<OpenNewScene>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagActive))
        {
            openNewScene.OpenScene();
        }
    }
}
