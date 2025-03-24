using System;
using UnityEngine;

public class SpotCharacter : MonoBehaviour
{
    public Action <CharacterMovement> characterSpotted;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterMovement character))
        {
            characterSpotted?.Invoke(character);
        }
    }
}
