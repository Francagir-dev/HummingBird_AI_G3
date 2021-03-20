using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Patient : MonoBehaviour
{
    private int patient_id;
    private string name;

    public int PatientID
    {
        get => patient_id;
        set => patient_id = value;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public Patient(string name)
    {
        this.name = name;
    }
}