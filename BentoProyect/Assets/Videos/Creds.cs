using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creds : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject CredCanva;

    // Update is called once per frame
    public void Credits()
    {
       mainMenu.SetActive(false); 
       CredCanva.SetActive(true);
    }

    public void Return()
    {
        mainMenu.SetActive(true);
        CredCanva.SetActive(false);
    }
}
