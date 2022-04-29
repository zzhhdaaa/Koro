using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeefCounter : MonoBehaviour
{
    [HideInInspector]
    public int beef;

    public Text count;

    // Start is called before the first frame update
    void Start()
    {
        beef = 6;
    }

    // Update is called once per frame
    void Update()
    {
        count.text = "BEEF: " + beef;
    }
}
