using OculusSampleFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayActivation : MonoBehaviour
{
    [SerializeField] Interactable interactable;
    [SerializeField] Transform playerTransform;
    private void Start()
    {
        interactable.ActionZoneEvent += PrintMe;
    }

    public void PrintMe(ColliderZoneArgs args)
    {
        if (args.InteractionT == InteractionType.Enter)
            playerTransform.position = transform.position;
    }
}