using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AmazingAssets.AdvancedDissolve;

public class TimeTravelMachine : MonoBehaviour
{
    public bool isActivated;

    bool isNormal = true;
    public GameObject dogNormal;
    public GameObject dogSocial;

    public AudioClip[] timeTravelSounds;
    AudioSource timeTravelSoundsSource;

    float timmer;
    float clip;

    VolumeWeightChange[] volumeWeightChanges;
    Wanderer[] wanderers;

    // Start is called before the first frame update
    void Start()
    {
        timeTravelSoundsSource = GetComponent<AudioSource>();
        volumeWeightChanges = FindObjectsOfType<VolumeWeightChange>();
        wanderers = FindObjectsOfType<Wanderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Timmer();
    }

    void Activated()
    {
        if (!isActivated)
        {
            return;
        }
        else
        {
            CityChange();
        }
    }

    void CityChange()
    {
        isNormal = !isNormal;
        dogNormal.SetActive(isNormal);
        dogSocial.SetActive(!isNormal);
    }

    void CityTransition()
    {
        clip = Mathf.PingPong(timmer, 1);
        if (isNormal)
        {
            AdvancedDissolveProperties.Cutout.Standard.UpdateGlobalProperty(AdvancedDissolveKeywords.GlobalControlID.Two, AdvancedDissolveProperties.Cutout.Standard.Property.Clip, clip);
            AdvancedDissolveProperties.Cutout.Standard.UpdateGlobalProperty(AdvancedDissolveKeywords.GlobalControlID.One, AdvancedDissolveProperties.Cutout.Standard.Property.Clip, 1-clip);
        }
        else
        {
            AdvancedDissolveProperties.Cutout.Standard.UpdateGlobalProperty(AdvancedDissolveKeywords.GlobalControlID.Two, AdvancedDissolveProperties.Cutout.Standard.Property.Clip, 1-clip);
            AdvancedDissolveProperties.Cutout.Standard.UpdateGlobalProperty(AdvancedDissolveKeywords.GlobalControlID.One, AdvancedDissolveProperties.Cutout.Standard.Property.Clip, clip);
        }
        VolumeTransition();
    }

    void Timmer()
    {
        if (isActivated)
        {
            if (timmer == 0)
            {
                if (isNormal)
                {
                    timeTravelSoundsSource.clip = timeTravelSounds[0];
                }
                else
                {
                    timeTravelSoundsSource.clip = timeTravelSounds[1];
                }
                timeTravelSoundsSource.Play();
                dogNormal.SetActive(true);
                dogSocial.SetActive(true);
                foreach (VolumeWeightChange volumeWeightChange in volumeWeightChanges)
                {
                    volumeWeightChange.isActivated = true;
                }
            }
            
            if (timmer < 1)
            {
                timmer += Time.deltaTime;
                CityTransition();
            }
            else
            {
                timmer = 1;
                CityTransition();
                foreach (VolumeWeightChange volumeWeightChange in volumeWeightChanges)
                {
                    volumeWeightChange.isActive = !volumeWeightChange.isActive;
                    volumeWeightChange.isActivated = false;
                }
                CityChange();
                WandererSwitch();
                isActivated = false;
                timmer = 0;
            }
        }
    }

    void VolumeTransition()
    {
        foreach (VolumeWeightChange volumeWeightChange in volumeWeightChanges)
        {
            volumeWeightChange.clip = clip;
        }
    }

    void WandererSwitch()
    {
        foreach (Wanderer wanderer in wanderers)
        {
            wanderer.GetComponent<NavMeshAgent>().enabled = isNormal;
        }
    }

    public void StartTimeTravel()
    {
        isActivated = true;
    }
}
