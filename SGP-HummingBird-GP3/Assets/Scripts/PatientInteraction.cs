using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientInteraction : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Player"))
        {
            Debug.LogWarning("I have been touched by the player");
        }
    }
}
