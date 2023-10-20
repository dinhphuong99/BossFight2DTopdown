using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjectChildren;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var gObj in gameObjectChildren)
        {
            gObj.SetActive(true);
            gObj.SetActive(false);
        }
    }

    private void SetActiveTrueObjectIndex(int i)
    {
        gameObjectChildren[i].SetActive(true);
    }

    private void SetActiveFalseObjectIndex(int i)
    {
        gameObjectChildren[i].SetActive(false);
    }
}
