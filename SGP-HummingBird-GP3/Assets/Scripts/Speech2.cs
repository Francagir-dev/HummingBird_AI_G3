﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech2 : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            speech();
        }
    }

    public void speech()
    {
        FindObjectOfType<AudioManager>().Play("patient2");
    }

}
