using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Model : MonoBehaviour
{
    private int model_id;
    private Patient patient;
    private string name;
    private float timeBeingWatched;

    public Patient Patient
    {
        get => patient;
        set => patient = value;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public float TimeBeingWatched
    {
        get => timeBeingWatched;
        set => timeBeingWatched = value;
    }


    public Model(Patient patient, string name, float timeBeingWatched)
    {
        this.patient = patient;
        this.name = name;
        this.timeBeingWatched = timeBeingWatched;
    }
}