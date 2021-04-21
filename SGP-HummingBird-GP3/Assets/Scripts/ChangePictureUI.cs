using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangePictureUI : MonoBehaviour
{
    public static ChangePictureUI Instance;
    public bool comparePatients = false;
    [Header("Canvases")] 
    [SerializeField] private GameObject infoPatient;
    [SerializeField] private GameObject infoComparePatients;

    [Header("UI")] 
    [SerializeField] private  GameObject buttonList;
    [Header("Patients")] 
    [SerializeField] private PatientInfo patient1;
    [SerializeField] private PatientInfo patient2;
   

    public PatientInfo Patient1
    {
        get => patient1;
        set => patient1 = value;
    }

    public PatientInfo Patient2
    {
        get => patient2;
        set => patient2 = value;
    }
    private void Awake()
    {
        Instance = this;
    }
    public void ShowInfoPatient()
    {
        if(comparePatients == false)
            infoPatient.SetActive(true);
        else if(comparePatients == true)
            infoComparePatients.SetActive(true);
    }
    public void HideButtons()
    {

        buttonList.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
        buttonList.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
    }

    public void HideButton(int posButtn)
    {
        buttonList.transform.GetChild(posButtn).GetComponent<BoxCollider>().enabled = false;
    }
    public void ShowButton(int posButtn)
    {
        buttonList.transform.GetChild(posButtn).GetComponent<BoxCollider>().enabled = true;
    }
    public void ShowButtons()
    {
        buttonList.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
        buttonList.transform.GetChild(1).GetComponent<BoxCollider>().enabled = true;
    }
    
    public void GetInfoFromButton(int positionOfButton)
    {
        Debug.LogWarning(comparePatients);
        if (!comparePatients)
        {
            GameObject btnPatient = buttonList.transform.GetChild(positionOfButton).gameObject;
            patient1 = ScriptableObject.CreateInstance<PatientInfo>();
            patient1.LastName = btnPatient.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            patient1.Name = btnPatient.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
            patient1.HeartRate = Int32.Parse(btnPatient.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text);
            patient1.OxygenRate = Int32.Parse(btnPatient.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text);
            patient1.BloodPreassure =
                Int32.Parse(btnPatient.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text);
            patient1.Temperature = float.Parse(btnPatient.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text);
            Debug.LogWarning(patient1.Name + "    " +patient1.LastName);
        }
        else if (comparePatients)
        {
            GameObject btnPatient = buttonList.transform.GetChild(positionOfButton).gameObject;
            patient2 = ScriptableObject.CreateInstance<PatientInfo>();
            patient2.LastName = btnPatient.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            patient2.Name = btnPatient.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
            patient2.HeartRate = Int32.Parse(btnPatient.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text);
            patient2.OxygenRate = Int32.Parse(btnPatient.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text);
            patient2.BloodPreassure =
                Int32.Parse(btnPatient.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text);
            patient2.Temperature = float.Parse(btnPatient.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text);
        }
    }
}