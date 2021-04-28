using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPatietTutorial : MonoBehaviour
{
    [SerializeField] private GameObject patientCanvasInfo;
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Player"))
        {
            patientCanvasInfo.SetActive(true);
            StartCoroutine(HideCanvas());
        }
    }

    IEnumerator HideCanvas()
    {
        patientCanvasInfo.SetActive(false);
        yield return new WaitForSeconds(2);
    }
}
