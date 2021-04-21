using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientInfo : ScriptableObject
{
    string _lastname;
    string _name;
    int _heartRate;
    int _oxygenRate;
    float _temperature;
    int _bloodPreassure;

    public string LastName
    {
        get => _lastname;
        set => _lastname = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int HeartRate
    {
        get => _heartRate;
        set => _heartRate = value;
    }

    public int OxygenRate
    {
        get => _oxygenRate;
        set => _oxygenRate = value;
    }

    public float Temperature
    {
        get => _temperature;
        set => _temperature = value;
    }

    public int BloodPreassure
    {
        get => _bloodPreassure;
        set => _bloodPreassure = value;
    }


    public PatientInfo(string lastname, string name, int heartRate, int oxygenRate, float temperature,
        int bloodPreassure)
    {
        _lastname = lastname;
        _name = name;
        _heartRate = heartRate;
        _oxygenRate = oxygenRate;
        _temperature = temperature;
        _bloodPreassure = bloodPreassure;
    }
}
