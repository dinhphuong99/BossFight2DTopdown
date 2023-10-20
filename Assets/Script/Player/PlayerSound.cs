using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioSource rollSound;
    [SerializeField] private AudioSource swapSound;
    [SerializeField] private GameObject objectSwap;
    private int pPosition = 0;
    private int temppPosition = 0;

    private SwapWeapon swapWeapon;
    // Start is called before the first frame update
    void Start()
    {
        swapWeapon = objectSwap.GetComponent<SwapWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        temppPosition = swapWeapon.GetpPosition();
        if(temppPosition != pPosition)
        {
            pPosition = temppPosition;
            SwapSound();
        }
    }

    public void RollSound()
    {
        rollSound.Play();
    }

    public void SwapSound()
    {
        swapSound.Play();
    }
}
