using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindVectorRunAway : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    public Vector3 moveInput = Vector3.zero;
    [SerializeField] private GameObject upObject;
    [SerializeField] private GameObject downObject;
    [SerializeField] private GameObject leftObject;
    [SerializeField] private GameObject rightObject;
    [SerializeField] private GameObject centerObject;

    private DetectionCollider upCollider;
    private DetectionCollider downCollider;
    private DetectionCollider leftCollider;
    private DetectionCollider rightCollider;

    private bool canUp = false;
    private bool canDown = false;
    private bool canLeft = false;
    private bool canRight = false;

    private float upDistance = -1f;
    private float downDistance = -1f;
    private float leftDistance = -1f;
    private float rightDistance = -1f;
    private float maxDistance = 0f;

    private Vector3 vectorUp;
    private Vector3 vectorDown;
    private Vector3 vectorLeft;
    private Vector3 vectorRight;

    // Start is called before the first frame update
    void Start()
    {
        upCollider = upObject.GetComponent<DetectionCollider>();
        downCollider = downObject.GetComponent<DetectionCollider>();
        leftCollider = leftObject.GetComponent<DetectionCollider>();
        rightCollider = rightObject.GetComponent<DetectionCollider>();

        InvokeRepeating("UpdateDirect", 0f, 0.2f);
    }

    private void UpdateDirect()
    {
        UpdateCanMove();
        UpdateDistance();
        UpdateVectorDirect();
        UpdateMoveInput();
    }

    private void UpdateCanMove()
    {
        canUp = !upCollider.isTouch;
        canDown = !downCollider.isTouch;
        canLeft = !leftCollider.isTouch;
        canRight = !rightCollider.isTouch;
    }

    private void UpdateVectorDirect()
    {
        vectorUp = (upObject.transform.position - centerObject.transform.position).normalized;
        vectorDown = (downObject.transform.position - centerObject.transform.position).normalized;
        vectorLeft = (leftObject.transform.position - centerObject.transform.position).normalized;
        vectorRight = (rightObject.transform.position - centerObject.transform.position).normalized;
    }

    private void UpdateDistance()
    {
        upDistance = canUp ? Vector3.Distance(targetObject.transform.position, upObject.transform.position) : -1f;
        downDistance = canDown ? Vector3.Distance(targetObject.transform.position, downObject.transform.position) : -1f;
        leftDistance = canLeft ? Vector3.Distance(targetObject.transform.position, leftObject.transform.position) : -1f;
        rightDistance = canRight ? Vector3.Distance(targetObject.transform.position, upObject.transform.position) : -1f;
    }

    private void UpdateMoveInput()
    {
        maxDistance = Mathf.Max(upDistance, downDistance, leftDistance, rightDistance);

        if (upDistance == maxDistance)
        {
            moveInput = vectorUp;
        }
        else if (leftDistance == maxDistance)
        {
            moveInput = vectorLeft;
        }
        else if (downDistance == maxDistance)
        {
            moveInput = vectorDown;
        }
        else if (rightDistance == maxDistance)
        {
            moveInput = vectorRight;
        }
    }
}
