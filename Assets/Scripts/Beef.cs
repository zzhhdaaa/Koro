using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beef : MonoBehaviour
{
    public GameObject effect;
    Bark bark;

    // Start is called before the first frame update
    void Start()
    {
        bark = FindObjectOfType<Bark>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //FindObjectOfType<BeefCounter>().beef++;
        Instantiate(effect, transform.position, transform.rotation);
        bark.ChangeVoice();
        Destroy(gameObject);
    }
}
