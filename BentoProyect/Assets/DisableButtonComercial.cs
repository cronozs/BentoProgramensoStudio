using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DisableButtonComercial : MonoBehaviour
{
    [SerializeField] public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        button.SetActive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
