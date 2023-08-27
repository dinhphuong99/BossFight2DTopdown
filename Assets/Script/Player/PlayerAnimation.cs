using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerMovement playerMovement;
    private LifeWithRevival playerLife;
    private RollSkill rollSkill;
    [SerializeField] private GameObject character;
    private bool isRoll = false;
    private bool isMove = false;

    private enum AllCharacterState { Idle, Death, Walk, Roll }

    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        anim = character.GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        playerLife = GetComponent<LifeWithRevival>();
        rollSkill = GetComponent<RollSkill>();
    }

    private void Update()
    {
        isRoll = rollSkill.GetIsRoll();
        isMove = (playerMovement.dirX != 0 | playerMovement.dirY != 0);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (playerLife.isDead)
        {
            ChangeAnimationState(AllCharacterState.Death.ToString());
        }
        else if (isRoll)
        {
            ChangeAnimationState(AllCharacterState.Roll.ToString());
        }
        else if (isMove && !isRoll)
        {
            ChangeAnimationState(AllCharacterState.Walk.ToString());
        }
        else if (!isMove && !isRoll)
        {
            ChangeAnimationState(AllCharacterState.Idle.ToString());
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
