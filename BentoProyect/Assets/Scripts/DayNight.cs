using System;
using System.Collections;

using UnityEngine;

public class DayNight : MonoBehaviour
{
    [SerializeField] public GameObject background;
    [SerializeField] public Material day;
    [SerializeField] public Material night;
    // Start is called before the first frame update
    
    // Update is called once per frame

    private void Start()
    {
        StartCoroutine(DayToNight());

    }

   
    IEnumerator DayToNight()
    {
        
        Renderer rend = background.GetComponent<Renderer>();
        yield return new WaitForSeconds(60);
        rend.material = night;
        Night();

    }

    public void Night()
    {
        StartCoroutine(NightToDay());
    }

    IEnumerator NightToDay()
    {
        Renderer rend = background.GetComponent<Renderer>();
        yield return new WaitForSeconds(60);
        rend.material = day;
        Day();
    }

    public void Day()
    {
        StartCoroutine(DayToNight());
    }
}
