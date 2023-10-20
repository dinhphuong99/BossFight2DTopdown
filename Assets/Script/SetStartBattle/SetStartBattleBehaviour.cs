using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartBattleBehaviour : MonoBehaviour
{
    [SerializeField] private string tagSetStart;
    [SerializeField] private GameObject gate;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetBeginStartBattle()
    {
        PlayerPrefs.SetInt("startBattle", 1);
        PlayerPrefs.Save();
    }

    public void SetEndStartBattle()
    {
        PlayerPrefs.SetInt("startBattle", 0);
        PlayerPrefs.Save();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagSetStart))
        {
            SetEndStartBattle();
            gate.SetActive(true);
        }
    }


}
