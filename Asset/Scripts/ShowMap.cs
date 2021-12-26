using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowMap : MonoBehaviour
{
    public GameObject Map;
    public SwitchScene start;
    // Start is called before the first frame update
    void Start()
    {
        MapInitialize();
    }
    public void MapInitialize () {
        Map  = GameObject.Find("Map of Physics");
        Map.SetActive(false);
        Debug.Log("Map is" + Map.activeInHierarchy);
    }

    public void PressMapButton() {
        Map.SetActive(!Map.activeSelf);
        Debug.Log("Map is" + Map.activeInHierarchy);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartMenu");
            start.startMenu();
            Debug.Log("Esc is pressed");
        }
    }
}
