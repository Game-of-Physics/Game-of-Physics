using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public GameObject Menu;
    public GameObject SetOptions;
    public GameObject Diff;
    public GameObject Lang;

    public void startMenu () {
        Menu.SetActive(true);
        SetOptions.SetActive(false);
        Debug.Log("Settings are " + SetOptions.activeInHierarchy);
        Diff.SetActive(false);
        Debug.Log("Difficulties are " + Diff.activeInHierarchy);
        Lang.SetActive(false);
    }

    public void LoadGame () {
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
        Debug.Log("Load New Game.");
    }
    public void GameSettings () {
        Menu.SetActive(false);
        SetOptions.SetActive(true);
        Debug.Log("Settings are " + SetOptions.activeInHierarchy);
    }
    public void DiffSettings () {
        SetOptions.SetActive(false);
        Diff.SetActive(true);
    }
    public void LangSettings () {
        SetOptions.SetActive(false);
        Lang.SetActive(true);
    }
    public void ExitGame () {
        Application.Quit();
    }

    public void B2startMenuu () {
        startMenu();
    }

    public void B2GameSettings () {
        Diff.SetActive(false);
        Lang.SetActive(false);
        GameSettings();
    }

    void Start () {
        Menu = GameObject.Find("Menu");
        SetOptions = GameObject.Find("SetOptions");
        Diff = GameObject.Find("Diff");
        Lang = GameObject.Find("Lang");
        startMenu();
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            startMenu();
            Debug.Log("Esc is pressed");
        }
    }
}
