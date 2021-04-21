using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowBothPatientsInfo : MonoBehaviour
{
    string[] patientInfor = 
    {
        "Patient Info: \nMale - 65 \nHeight - 181 cm \nWeight - 95.1\nBlood type - B+\n \n \nAllergies",
        "Patient Info: \nMale - 72 \nHeight - 195 cm \nWeight - 108.6\nBlood type - 0+\n \n \nAllergies"
    };

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
        if (ChangePictureUI.Instance.Patient1.Name.Equals("Paul H"))
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
        if (ChangePictureUI.Instance.Patient2.Name.Equals("Paul H"))
        {
            patientInfoPatient2.text = patientInfor[0];
        }
        else
        {
            patientInfoPatient2.text = patientInfor[1];
        }
    }
}