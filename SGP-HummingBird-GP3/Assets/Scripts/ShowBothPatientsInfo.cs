using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowBothPatientsInfo : MonoBehaviour
{
    string[] patientInfor = new String[]
    {
        "Patient Info: \nMale - 65 \nHeight - 181 cm \nWeight - 95.1\nBlood type - B+\n \n \nAllergies",
        "Patient Info: \nMale - 72 \nHeight - 195 cm \nWeight - 108.6\nBlood type - 0+\n \n \nAllergies"
    };

    string[] nurseNotesString = new String[]
    {
        "Nurse's note: \nThe patient has shortness if breath and a fever. His son was tested positive for COVID last week. Rapid breathing, high heart rate, no available oxygen.\n \n Past medical hx- HTN, high, DM.\nMedications- Simvastatin, NTG, Metoprolol, and Metaformin\nAllergies - NKDA",
        "Nurse's note: \nThe patient has shortness if breath but not a fever. His had a contact that tested positive for COVID 5 days ago. normal heart rate, available oxygen.\n \n  Lorem ipsum \n Medications- Insulin\nAllergies - NKDA"
    };

    [SerializeField] private TextMeshProUGUI nurseNotes;
    [Header("Patient 1")] [SerializeField] private TextMeshProUGUI patient1NameTxT;
    [SerializeField] private TextMeshProUGUI heartRatePatient1;
    [SerializeField] private TextMeshProUGUI oxygenLevelPatient1;
    [SerializeField] private TextMeshProUGUI bloodPreassurePatient1;
    [SerializeField] private TextMeshProUGUI temperaturePatient1;
    [SerializeField] private TextMeshProUGUI patientInfoPatient1;

    [Header("Patient 2")] [SerializeField] private TextMeshProUGUI patient2NameTxT;
    [SerializeField] private TextMeshProUGUI heartRatePatient2;
    [SerializeField] private TextMeshProUGUI oxygenLevelPatient2;
    [SerializeField] private TextMeshProUGUI bloodPreassurePatient2;
    [SerializeField] private TextMeshProUGUI temperaturePatient2;
    [SerializeField] private TextMeshProUGUI patientInfoPatient2;

    private void OnEnable()
    {
        patient1NameTxT.text =
            ChangePictureUI.Instance.Patient1.Name + " " + ChangePictureUI.Instance.Patient1.LastName;
        heartRatePatient1.text = ChangePictureUI.Instance.Patient1.HeartRate.ToString();
        oxygenLevelPatient1.text = ChangePictureUI.Instance.Patient1.OxygenRate.ToString();
        bloodPreassurePatient1.text = ChangePictureUI.Instance.Patient1.BloodPreassure.ToString();
        temperaturePatient1.text = ChangePictureUI.Instance.Patient1.Temperature + " ºC";
        if (ChangePictureUI.Instance.Patient1.Name.Equals("Paul H."))
        {
            patientInfoPatient1.text = patientInfor[0];
        }
        else
        {
            patientInfoPatient1.text = patientInfor[1];
        }
        
        patient2NameTxT.text =
            ChangePictureUI.Instance.Patient2.Name + " " + ChangePictureUI.Instance.Patient2.LastName;
        heartRatePatient2.text = ChangePictureUI.Instance.Patient2.HeartRate.ToString();
        oxygenLevelPatient2.text = ChangePictureUI.Instance.Patient2.OxygenRate.ToString();
        bloodPreassurePatient2.text = ChangePictureUI.Instance.Patient2.BloodPreassure.ToString();
        temperaturePatient2.text = ChangePictureUI.Instance.Patient2.Temperature + " ºC";
        if (ChangePictureUI.Instance.Patient2.Name.Equals("Paul H."))
        {
            patientInfoPatient2.text = patientInfor[0];
        }
        else
        {
            patientInfoPatient2.text = patientInfor[1];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}