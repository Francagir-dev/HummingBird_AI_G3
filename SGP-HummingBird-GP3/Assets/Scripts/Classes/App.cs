using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class App : MonoBehaviour
{
    private int _appID;
    private GameSession _gs;
    private Patient _patient;
    private float _timeSpentOnPatient;
    private float _timeInfoOnPatient;
    private int _timesClickedPatientInfo;

    public GameSession Gs
    {
        get => _gs;
        set => _gs = value;
    }

    public Patient Patient
    {
        get => _patient;
        set => _patient = value;
    }

    public float TimeSpentOnPatient
    {
        get => _timeSpentOnPatient;
        set => _timeSpentOnPatient = value;
    }

    public float TimeInfoOnPatient
    {
        get => _timeInfoOnPatient;
        set => _timeInfoOnPatient = value;
    }

    public int TimesClickedPatientInfo
    {
        get => _timesClickedPatientInfo;
        set => _timesClickedPatientInfo = value;
    }


    public App(GameSession gs, Patient patient, float timeSpentOnPatient, float timeInfoOnPatient,
        int timesClickedPatientInfo)
    {
        _gs = gs;
        _patient = patient;
        _timeSpentOnPatient = timeSpentOnPatient;
        _timeInfoOnPatient = timeInfoOnPatient;
        _timesClickedPatientInfo = timesClickedPatientInfo;
    }
}