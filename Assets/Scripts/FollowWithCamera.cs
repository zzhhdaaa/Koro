using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWithCamera : MonoBehaviour
{
    public GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.transform.position;
    }
}
