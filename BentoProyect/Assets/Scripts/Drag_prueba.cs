using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Drag_prueba : MonoBehaviour
{
    Vector3 offset;
    public string destinationTag = "DropArea";
    public GameObject orden;
    public GameObject canvaWin, canvaLose;
    public float puntaje=0;
    private GameObject copia;
    
    void OnMouseDown()
    {
        copia = Instantiate(gameObject,transform.position,Quaternion.identity);
        offset = transform.position - MouseWorldPosition();
        transform.GetComponent<Collider>().enabled = false;
    }
    
    void OnMouseDrag()
    {
        copia.transform.position = MouseWorldPosition() + offset;
    }
 
    void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MouseWorldPosition() - Camera.main.transform.position;
        RaycastHit hitInfo;
        if(Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            if(hitInfo.transform.tag == destinationTag)
            {
                copia.transform.position = hitInfo.transform.position;
                Verificar();
            }
            else
            {
                Destroy(copia.gameObject);
            }
        }
        transform.GetComponent<Collider>().enabled = true;
    }
    
    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    void Verificar()
    {
        if (gameObject.tag == orden.tag)
        {
            StartCoroutine(Gone(canvaWin));
            puntaje += 1;
            StartCoroutine(DestroyGameobject());
        }
        else
        {
            StartCoroutine(Gone(canvaLose));
        }
    }

    IEnumerator Gone(GameObject canva)
    {
        canva.SetActive(true);
        yield return new WaitForSeconds(1);
        canva.SetActive(false);
    }

    IEnumerator DestroyGameobject()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
