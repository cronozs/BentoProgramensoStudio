using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Validation : MonoBehaviour
{
    [SerializeField] private GameObject[] peticiones = new GameObject[3];
    [SerializeField] private GameObject canvaWin;
    [SerializeField] private GameObject canvalosse;
    [SerializeField] private Box[] orderZones = new Box[3];
    [SerializeField] private IngredientList player;
    [SerializeField] private float canvaTime;
    private bool verify = true;
    public bool canVerify = true;
    public bool canValidate = true;



    // Update is called once per frame
    void Update()
    {
        Validaciones();
    }


    private void Validaciones()
    {
        if (canValidate)
        {
            if (orderZones[0].tag != "DropArea" && orderZones[1].tag != "DropArea" && orderZones[2].tag != "DropArea")
            {
                if (peticiones[0].tag != orderZones[0].tag || peticiones[1].tag != orderZones[1].tag || peticiones[2].tag != orderZones[2].tag)
                    verify = false;
                if (canVerify) Ver();

                canValidate = false;

            }
        }
       
    }

    private void Ver()
    {
        if(verify)
        {
            canvaWin.SetActive(true);
            StartCoroutine(Gone(canvaWin));
            showPoints.instance.addScore();
            canVerify = false;
        }
        else
        {
            canvalosse.SetActive(true);
            StartCoroutine(Gone(canvalosse));
            canVerify = false;
        }
    }

    IEnumerator Gone(GameObject canva)
    {
        yield return new WaitForSeconds(canvaTime);
        canva.SetActive(false);
        verify = true;
        foreach(var zone in orderZones)
        {
            zone.canDes = true;
            zone.tag = "DropArea";
            var col = zone.GetComponent<BoxCollider>();
            col.enabled = false;
        }
        
        canValidate = true;
    }

    public void Reasingnar()
    {
        player  = FindObjectOfType<IngredientList>();
        for (int i = 0; i < player.show.Length; i++)
        {
            peticiones[i] = player.show[i].gameObject;
        }
    }

}
