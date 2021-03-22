using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    public static PersistentManager persistentDataManager;
    public static InfoToPersist infoToPersist;

    public void Awake()
    {
        if (persistentDataManager == null)
        {
            DontDestroyOnLoad(gameObject);
            persistentDataManager = this;
        }

        if (persistentDataManager != this)
        {
            Destroy(this);
        }
    }
}

[System.Serializable]
public class InfoToPersist
{
    public static InfoToPersist infoToPersist;
    public string username;

    public void Awake()
    {
        infoToPersist = this;
    }
}