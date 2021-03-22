using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Model : MonoBehaviour
{
    private int _modelID;
    private Patient _patient;
    private string _name;
    private float _timeBeingWatched;

    public Patient Patient
    {
        get => _patient;
        set => _patient = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public float TimeBeingWatched
    {
        get => _timeBeingWatched;
        set => _timeBeingWatched = value;
    }


    public Model(Patient patient, string name, float timeBeingWatched)
    {
        _patient = patient;
        _name = name;
        _timeBeingWatched = timeBeingWatched;
    }
}