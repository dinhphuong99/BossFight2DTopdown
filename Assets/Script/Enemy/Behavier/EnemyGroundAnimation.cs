using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundAnimation : MonoBehaviour
{
    private DetectionCollider detectionCollider;
    private bool canRoll = false;
    [SerializeField] private GameObject detech;
    [SerializeField] private GameObject objectLife;
    private Animator anim;
    private string currentState;
    private Life life;

    // Start is called before the first frame update
    void Start()
    {
        detectionCollider = detech.GetComponent<DetectionCollider>();
        anim = GetComponent<Animator>();
        life = objectLife.GetComponent<Life>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectionCollider.isTouch)
        {
            canRoll = true;
        }

        UpdateAnimationState();
    }

    public void SetRollFalse()
    {
        canRoll = false;
    }


    private void UpdateAnimationState()
    {
        if (life.GetCurrentHealth() <= 0)
        {
            ChangeAnimationState("Die");
        }
        else if (canRoll)
        {
            ChangeAnimationState("Roll");
        }
        else
        {
            ChangeAnimationState("Walk");
        }
    }

    private void ChangeAnimationState(string newState)
    {
        if (anim == null)
        {
            Debug.LogError("Animator is not assigned!");
            return;
        }

        if (string.IsNullOrEmpty(newState))
        {
            Debug.LogError("New state is null or empty!");
            return;
        }

        if (!anim.HasState(0, Animator.StringToHash(newState)))
        {
            Debug.LogError("New state is not a valid animator state: " + newState);
            return;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName(newState))
        {
            return;
        }

        currentState = newState;
        anim.Play(currentState);
    }
}
