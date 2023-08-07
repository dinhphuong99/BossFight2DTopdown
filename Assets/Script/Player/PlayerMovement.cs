using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private Vector3 moveInput;
    [SerializeField] private SpriteRenderer characterSR;
    public float dirX { get; set; }
    public float dirY { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        moveInput.x = dirX;
        moveInput.y = dirY;

        transform.position += moveInput.normalized * speed * Time.fixedDeltaTime;
        Flip();
    }

    private void Flip()
    {
        if (dirX < 0)
        {
            characterSR.transform.localScale = new Vector3(-1, 1, 0);
        }
        else if (dirX > 0)
        {
            characterSR.transform.localScale = new Vector3(1, 1, 0);
        }
    }
}
