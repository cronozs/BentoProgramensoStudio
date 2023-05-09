using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Validation : MonoBehaviour
{
    [SerializeField] private GameObject[] areas = new GameObject[3];
    [SerializeField] private GameObject[] peticiones = new GameObject[3];
    [SerializeField] private GameObject canvaWin;
    [SerializeField] private GameObject canvalosse;
    [SerializeField] private Box[] orderZones = new Box[3];
    [SerializeField] private IngredientList player;
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
            if (areas[0].tag != "DropArea" && areas[1].tag != "DropArea" && areas[2].tag != "DropArea")
            {
                for (int i = 0; i < peticiones.Length -1; i++)
                {
                    bool match = false;
                    for (int j = 0; j < areas.Length-1; j++)
                    {
                        if (peticiones[i].tag == areas[j].tag)
                        {
                            match = true;
                        }
                    }
                    Debug.Log(match);
                    if (!match)
                    {
                        verify = false;
                    }

                }
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
        yield return new WaitForSeconds(1);
        canva.SetActive(false);
        verify = true;
        foreach(var zone in orderZones)
        {
            zone.canDes = true;
        }
        foreach (var area in areas)
        {
            area.tag = "DropArea";
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
