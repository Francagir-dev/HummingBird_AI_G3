using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Model : ScriptableObject
{
    private int _modelID;
    private Patient _patient;
    private string _name;
    private float _timeBeingWatched;

    #region Getters and Setters

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

    #endregion

    #region Constructors

    public Model()
    {
    }

    public Model(int modelID, Patient patient, string name, float timeBeingWatched)
    {
        _modelID = modelID;
        _patient = patient;
        _name = name;
        _timeBeingWatched = timeBeingWatched;
    }

    public Model(Patient patient, string name, float timeBeingWatched)
    {
        _patient = patient;
        _name = name;
        _timeBeingWatched = timeBeingWatched;
    }

    public override string ToString()
    {
        return _modelID + ".- name: " + _name + ", time being watched: " + _timeBeingWatched + " from patient : " +
               _patient.ToString();
    }

    #endregion
}