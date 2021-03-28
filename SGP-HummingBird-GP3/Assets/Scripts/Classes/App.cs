using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class App : MonoBehaviour
{
    #region Constructors

    public App()
    {
    }

    public App(int appID, GameSession gs, Patient patient, float timeSpentOnPatient, float timeInfoOnPatient,
        int timesClickedPatientInfo)
    {
        _appID = appID;
        _gs = gs;
        _patient = patient;
        _timeSpentOnPatient = timeSpentOnPatient;
        _timeInfoOnPatient = timeInfoOnPatient;
        _timesClickedPatientInfo = timesClickedPatientInfo;
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

    #endregion

    #region Attributes

    private int _appID;
    private GameSession _gs;
    private Patient _patient;
    private float _timeSpentOnPatient;
    private float _timeInfoOnPatient;
    private int _timesClickedPatientInfo;

    #endregion

    #region Getters and Setters

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

    #endregion

    #region Methods

    public override string ToString()
    {
        return _appID + ".- GameSession: " + _gs.ToString() + " ,Patient: " + _patient.ToString() +
               " timeSpentOnPatient: " +
               _timeSpentOnPatient + " timeInfoOnPatient: " + _timeInfoOnPatient + " ,timesClickedPatientInfo: " +
               _timesClickedPatientInfo;
    }

    #endregion
}