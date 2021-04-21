using System;
using TMPro;
using UnityEngine;

public class ChangePictureUI : MonoBehaviour
{
    public static ChangePictureUI Instance;

    [Header("Canvases")] [SerializeField] private GameObject infoPatient;
    [SerializeField] private GameObject infoComparePatients;
    [SerializeField] private GameObject listPatientsCompare;

    [Header("UI")] [SerializeField] private  GameObject buttonList;
    [Header("Patients")] [SerializeField] private PatientInfo patient1;
    [SerializeField] private PatientInfo patient2;

    // [SerializeField] private Sprite[] appSprites;
    // [SerializeField] private Image appScreen;


    // [SerializeField] private GameObject[] canvases;
    [SerializeField] private bool comparePatients;

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

    public bool ComparePatients
    {
        get => comparePatients;
        set => comparePatients = value;
    }

    //public void ChangeSprite(int spriteChange)
    //{
    //    appScreen.sprite = appSprites[spriteChange];
    //}
    private void Awake()
    {
        Instance = this;
    }

    public void ShowInfoPatient()
    {
        if(!comparePatients)
            infoPatient.SetActive(true);
        else 
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