using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject Balloon, Exclamation, Pmail;
    public string Text;

    private GameObject _curBalloon;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("zhaodaole");
        if (col.tag != "Player") { return; }
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null) {
            Debug.Log("meizhaodao");
            return; }
        Debug.Log("zhaodaole");

        _curBalloon = Instantiate(Balloon, canvas.transform); //create text balloon
        //_curBalloon.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2.0f, 15); //position text balloon
        _curBalloon.GetComponent<Text>().text = Text; //update text in balloon
        //_curBalloon.transform.parent = canvas.transform; //add balloon under Canvas
        Exclamation.SetActive(false);
        Pmail.SetActive(true);
        audioSource.Play();
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag != "Player") { return; }
        if (_curBalloon == null) { return; }
        Destroy(_curBalloon);
        Exclamation.SetActive(true);
        Pmail.SetActive(false);
    }
}