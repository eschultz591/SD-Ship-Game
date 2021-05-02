using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Button startButton, level1, level2, level3;
    public GameObject controls;
    public void PlayGame ()
    {
        startButton.gameObject.SetActive(false);
        controls.gameObject.SetActive(false);
        level1.gameObject.SetActive(true);
        level2.gameObject.SetActive(true);
        level3.gameObject.SetActive(true);
    }


    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }
}
