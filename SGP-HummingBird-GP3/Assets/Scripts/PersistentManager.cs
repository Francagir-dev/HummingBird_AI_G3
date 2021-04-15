using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    public static PersistentManager persistentDataManager;
    public string username;

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