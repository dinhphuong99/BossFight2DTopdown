using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoteBullet : MonoBehaviour
{
    private Vector2 vector;

    public void SetVector(Vector2 vector)
    {
        this.vector = vector;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, Vector2ToAngle(vector));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static float Vector2ToAngle(Vector2 vector)
    {
        return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg + 180;
    }
}
