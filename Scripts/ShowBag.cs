using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBag : MonoBehaviour
{
    public GameObject bag;

    public void bagInitialze () {
        bag  = GameObject.Find("bagContent");
        bag.SetActive(false);
    }

    public void OpenBag (){
        bag.SetActive(!bag.activeSelf);
    }
    // Start is called before the first frame update
    void Start()
    {
        bagInitialze();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
