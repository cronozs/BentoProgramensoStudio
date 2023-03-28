using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IngredientList : MonoBehaviour
{
    [SerializeField] private GameObject[] ingredients = new GameObject[3];
    [SerializeField] private Drag_prueba[] ingred = new Drag_prueba[3];
    [SerializeField] private Image show;
    [SerializeField] private Image timer;
    [SerializeField] private GameObject Loose;


    private float _time;
    [SerializeField] private float _actualTime;
    private Renderer _renderer;
    private int _selector;

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    private void ChoseIngredients()
    {
        _selector = Random.Range(0, ingredients.Length);
        _renderer = ingredients[_selector].GetComponent<Renderer>();
        show.tag = ingredients[_selector].tag;
        show.material = _renderer.material;
    }

    private void Timer()
    {
        _actualTime = Time.time - _time;
        if (_actualTime <= 10)
        {
            float fill = _actualTime / 10;
            fill = (1 - fill) + 0;  
            timer.fillAmount = fill;
        }
        else if (_actualTime >= 10 && _actualTime <= 10.4f)
        {
            Loose.SetActive(true);
            MoveX();
        }
        else
        {
            StartCoroutine(ShowCanva());
            MoveX();
        }
    }

    IEnumerator ShowCanva()
    {
        yield return new WaitForSeconds(1.2f);
        Loose.SetActive(false);
    }

    private void MoveX()
    {
        this.transform.Translate(5 * Time.deltaTime,0,0);
    }

    private void OnBecameInvisible()
    {
        CloneClient();
        Destroy(this.gameObject);   
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        _time = _actualTime;
        this.transform.Translate(0, 0, 0);
        foreach(var ing in ingred)
        {
            ing.orden = show.gameObject;
        }
        ChoseIngredients();

    }

    private void CloneClient()
    {
        this.transform.position = new Vector3(-15, 5, 5);
        Instantiate(this.gameObject);
        MoveX();
    }
}
