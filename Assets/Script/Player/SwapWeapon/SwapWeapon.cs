using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeapon : MonoBehaviour
{
    [SerializeField] private GameObject []weapons;
    private int pPosition = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        weapons[pPosition].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            weapons[pPosition].SetActive(false);
            if (pPosition + 1 >= weapons.Length)
            {
                pPosition = 0;
                weapons[pPosition].SetActive(true);
            }
            else
            {
                pPosition = pPosition + 1;
                weapons[pPosition].SetActive(true);
            }
        }
    }
}
