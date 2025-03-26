using System;
using UnityEngine;

public class SpotCharacter : MonoBehaviour
{
    [HideInInspector] public Action <CharacterBehaviour> characterSpotted;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterBehaviour character))
        {
            characterSpotted?.Invoke(character);
        }
    }
}
