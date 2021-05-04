using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientInteraction : MonoBehaviour
{
    //[SerializeField] private GameObject metrics;
    float timeOfSession = 0.0f;
    float StartTime = 0.0f;
    private bool hasBeenSent;
    private string playerName = "Test Subject Alpha X";
    public event EventHandler OnPatientTouched;

    public static PatientInteraction patientInteraction;

    private void Awake()
    {
        patientInteraction = this;
        StartTime = Time.time;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!hasBeenSent)
            {
                if (PersistentManager.persistentDataManager != null)
                {
                    playerName = PersistentManager.persistentDataManager.username;
                }

                timeOfSession = Time.time - StartTime;
                DataBaseManager.dbManager.CreateGameSession(playerName,
                    DateTime.UtcNow.ToLocalTime().ToString(), 7.0f, timeOfSession);
                Debug.Log("Saved");
                hasBeenSent = true;
            }
        }

        //metrics.SetActive(true);
    }
}