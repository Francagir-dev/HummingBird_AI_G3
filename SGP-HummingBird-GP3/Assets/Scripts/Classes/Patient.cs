using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Patient : ScriptableObject
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

    public Patient(int patientID, string name)
    {
        _patientID = patientID;
        _name = name;
    }

    public Patient(string name)
    {
        _name = name;
    }

    public override string ToString()
    {
        return _patientID + ".- name: " + _name+". ";
    }
}