using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMeleePlayer : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject weapon;
    private ActiveWeapon activeWeapon;
    private MeleeWeaponsCollider meleeWeaponsCollider;
    private string currentState;
    private bool isAttack = false;
    private bool isOn = false;
    private bool isSlide = false;

    public bool GetIsSlide()
    {
        return this.isSlide;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = weapon.GetComponent<Animator>();
        activeWeapon = weapon.GetComponent<ActiveWeapon>();
        meleeWeaponsCollider = weapon.GetComponent<MeleeWeaponsCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        isOn = meleeWeaponsCollider.GetIsOn();
        isAttack = activeWeapon.GetIsAttack();

        if (!isOn && !isAttack)
        {
            isSlide = false;
            UpdateAnimationState();
        } else
        {
            isSlide = true;
            UpdateAnimationState();
        }
    }

    private void UpdateAnimationState()
    {
        if (isSlide)
        {
            ChangeAnimationState("Slide");
        }
        else
        {
            ChangeAnimationState("Idle");
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
