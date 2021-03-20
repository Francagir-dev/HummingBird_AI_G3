using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class App : MonoBehaviour
{
    private int app_id;
    private GameSession gs;
    private Patient patient;
    private float timeSpentOnPatient;
    private float timeInfoOnPatient;
    private int timesClickedPatientInfo;

    public GameSession Gs
    {
        get => gs;
        set => gs = value;
    }

    public Patient Patient
    {
        get => patient;
        set => patient = value;
    }

    public float TimeSpentOnPatient
    {
        get => timeSpentOnPatient;
        set => timeSpentOnPatient = value;
    }

    public float TimeInfoOnPatient
    {
        get => timeInfoOnPatient;
        set => timeInfoOnPatient = value;
    }

    public int TimesClickedPatientInfo
    {
        get => timesClickedPatientInfo;
        set => timesClickedPatientInfo = value;
    }


    public App(GameSession gs, Patient patient, float timeSpentOnPatient, float timeInfoOnPatient,
        int timesClickedPatientInfo)
    {
        this.gs = gs;
        this.patient = patient;
        this.timeSpentOnPatient = timeSpentOnPatient;
        this.timeInfoOnPatient = timeInfoOnPatient;
        this.timesClickedPatientInfo = timesClickedPatientInfo;
    }
}