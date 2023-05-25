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
        comerciales[i1].SetActive(true);
      
       
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }
}
