using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Validation : MonoBehaviour
{
    [SerializeField] private GameObject[] areas = new GameObject[3];
    [SerializeField] private GameObject[] peticiones = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Validaciones();
    }

    private void Validaciones()
    {
        if (peticiones[0].transform.tag == areas[0].transform.tag || peticiones[0].transform.tag == areas[1].transform.tag || peticiones[0].transform.tag == areas[2].transform.tag)
        {
            Debug.Log("una validacion");
        }
    }
}
