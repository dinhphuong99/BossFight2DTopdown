using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamerColliderSendDamage : MonoBehaviour
{
    [SerializeField] private GameObject sinkholeCrack;
    private bool isTouchSinkholeCrackCollider = false;

    // Start is called before the first frame update
    void Start()
    {
        isTouchSinkholeCrackCollider = sinkholeCrack.GetComponent<DetectionCollider>().isTouch;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
