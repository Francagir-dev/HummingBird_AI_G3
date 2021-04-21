using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ChangePatientInfo : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    string[] patientInfor = 
    {
        "Patient Info: \nMale - 65 \nHeight - 181 cm \nWeight - 95.1\nBlood type - B+\n \n \nAllergies",
        "Patient Info: \nMale - 72 \nHeight - 195 cm \nWeight - 108.6\nBlood type - 0+\n \n \nAllergies"
    };

    string[] nurseNotesString = 
    {
        "Nurse's note: \nThe patient has shortness if breath and a fever. His son was tested positive for COVID last week. Rapid breathing, high heart rate, no available oxygen.\n \n Past medical hx- HTN, high, DM.\nMedications- Simvastatin, NTG, Metoprolol, and Metaformin\nAllergies - NKDA",
        "Nurse's note: \nThe patient has shortness if breath but not a fever. His had a contact that tested positive for COVID 5 days ago. normal heart rate, available oxygen.\n \n  Lorem ipsum \n Medications- Insulin\nAllergies - NKDA"
    };

    [SerializeField] private TextMeshProUGUI nurseNotes;
    [Header("Patient 1")] 
    [SerializeField] private TextMeshProUGUI patient1NameTxT;
    [SerializeField] private TextMeshProUGUI heartRatePatient1;
    [SerializeField] private TextMeshProUGUI oxygenLevelPatient1;
    [SerializeField] private TextMeshProUGUI bloodPreassurePatient1;
    [SerializeField] private TextMeshProUGUI temperaturePatient1;
    [SerializeField] private TextMeshProUGUI patientInfoPatient1;


    private void OnEnable()
    {
        Debug.LogWarning(ChangePictureUI.Instance.comparePatients);
        patient1NameTxT.text = ChangePictureUI.Instance.Patient1.Name + " " + ChangePictureUI.Instance.Patient1.LastName;
        heartRatePatient1.text = ChangePictureUI.Instance.Patient1.HeartRate.ToString();
        oxygenLevelPatient1.text = ChangePictureUI.Instance.Patient1.OxygenRate.ToString();
        bloodPreassurePatient1.text = ChangePictureUI.Instance.Patient1.BloodPreassure.ToString();
        temperaturePatient1.text = ChangePictureUI.Instance.Patient1.Temperature + " ºC";
        if (ChangePictureUI.Instance.Patient1.Name.Equals("Paul H"))
        {
            patientInfoPatient1.text = patientInfor[0];
            nurseNotes.text = nurseNotesString[0];


        }
        else
        {
            patientInfoPatient1.text = patientInfor[1];
            nurseNotes.text = nurseNotesString[1];

        }

    }

    public void BackToComparePatients()
    {
        ChangePictureUI.Instance.comparePatients = true;
        if (ChangePictureUI.Instance.Patient1.Name.Equals("Paul H"))
        {
            ChangePictureUI.Instance.ShowButton(1);
        }
        else
        {
            ChangePictureUI.Instance.ShowButton(0);
        }

        canvas.SetActive(false);
    }
}