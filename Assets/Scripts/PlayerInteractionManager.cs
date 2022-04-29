using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionManager : MonoBehaviour
{
    public Camera cameraMain;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract(InputValue value)
    {
        Ray ray = cameraMain.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Interactables")
                {
                    print("ChengGongLe!");
                    hit.collider.GetComponent<TimeTravelMachine>().isActivated = true;
                }
            }
        }
    }
}