using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashToMenu : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(SceneChange());
        
    }

   

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(1);
    }
}
