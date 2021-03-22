using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Patient : MonoBehaviour
{
    private int _patientID;
    private string _name;

    public int PatientID
    {
        get => _patientID;
        set => _patientID = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public Patient(string name)
    {
        _name = name;
    }
}