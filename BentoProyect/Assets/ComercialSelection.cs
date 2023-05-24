using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComercialSelection : MonoBehaviour
{

    [SerializeField] public GameObject[] comerciales;
    
    // Start is called before the first frame update
    void Start()
    {
        
        int i1 = Random.Range(0, comerciales.Length);
        int i2 = Random.Range(comerciales.Length, 0);
        
        comerciales[i1].SetActive(false);
        comerciales[i2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }
}
