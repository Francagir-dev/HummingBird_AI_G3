using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PatientInteraction : MonoBehaviour
{
    //[SerializeField] private GameObject metrics;

    public event EventHandler OnPatientTouched;

    public static PatientInteraction patientInteraction;

    private void Awake()
    {
        patientInteraction = this;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
         OnPatientTouched.Invoke(this, EventArgs.Empty);
         // Debug.LogWarning("HEeeeee");
        }
        
        //metrics.SetActive(true);
    }
}