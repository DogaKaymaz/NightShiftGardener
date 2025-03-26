using System;
using UnityEngine;
[RequireComponent(typeof(CharacterMovement))]
public class CharacterAnimationHandler : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private Animator animator;
    private void Start()
    {
        characterMovement.characterMoved += OnCharacterMoved;
    }

    private void OnCharacterMoved(string movementType, float amount)
    {
        animator.SetFloat(movementType, amount);
    }
}
