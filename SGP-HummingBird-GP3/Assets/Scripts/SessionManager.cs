using UnityEngine;
using System;

public class SessionManager : MonoBehaviour
{


    private void Start()
    {
        
        PatientInteraction.patientInteraction.OnPatientTouched += PatientInteraction_OnPatientTouched;
    }

    private void PatientInteraction_OnPatientTouched(object sender, System.EventArgs e)
    {
        
        Debug.LogWarning("Saved");
    }
}