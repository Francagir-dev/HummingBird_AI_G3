using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech2 : MonoBehaviour
{
   private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("patient2");
        }
    }

}
