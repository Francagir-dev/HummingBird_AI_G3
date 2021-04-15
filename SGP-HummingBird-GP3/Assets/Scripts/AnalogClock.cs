using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AnalogClock : MonoBehaviour
{
    private float lastSecond = -1;
    private float lastMinute = -1;
    private float lastHour = -1;
    
    [Header("Arms")] 
    [SerializeField] private GameObject secondArm;
    [SerializeField] private GameObject minuteArm;
    [SerializeField] private GameObject hourArm;

    [SerializeField] AudioSource au;

    // Use this for initialization
    void Start()
    {
        au = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSecondArm();
        UpdateMinuteArm();
        UpdateHourArm();
    }

    void UpdateSecondArm()
    {
        if (lastSecond != System.DateTime.Now.Second || lastSecond == -1)
        {
            if (lastSecond != -1)
                au.Play();

            secondArm.transform.localRotation =
                Quaternion.Euler((System.DateTime.Now.Second / 60f) * 360f - 90, -90, -90);
            lastSecond = System.DateTime.Now.Second;
        }
    }

    void UpdateMinuteArm()
    {
        if (lastMinute != System.DateTime.Now.Minute || lastMinute == -1)
        {
            minuteArm.transform.localRotation =
                Quaternion.Euler((System.DateTime.Now.Minute / 60f) * 360f - 90, -90, -90);
            lastMinute = System.DateTime.Now.Minute;
        }
    }

    void UpdateHourArm()
    {
        if (lastHour != System.DateTime.Now.Hour || lastHour == -1)
        {
            hourArm.transform.localRotation =
                Quaternion.Euler(((System.DateTime.Now.Hour / 24f) * 360f) + 90f, -90, -90);
            lastHour = System.DateTime.Now.Hour;
        }
    }
}