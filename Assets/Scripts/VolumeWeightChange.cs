using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VolumeWeightChange : MonoBehaviour
{
    public Volume volume;
    public bool isActive;

    [HideInInspector]
    public bool isActivated; //from timeTravelMachine.isActivated

    [HideInInspector]
    public float clip = 1; //clip from timeTravelMachine.clip
    float realWeight;

    void Start()
    {

    }

    void Update()
    {
        if (isActivated)
        {
            if (isActive)
            {
                realWeight = 1 - clip; //realWeight goes from 1 to 0
            }
            else
            {
                realWeight = clip; //realWeight goes from 0 to 1
            }
            volume.weight = realWeight;
        }
    }
}
