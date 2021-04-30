using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech1 : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("patient1");
        }
    }

}
