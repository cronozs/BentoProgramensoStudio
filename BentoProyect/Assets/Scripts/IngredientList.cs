using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class IngredientList : MonoBehaviour
{
    [SerializeField] private GameObject[] ingredients = new GameObject[3];
    [SerializeField] private Drag_prueba[] ingred = new Drag_prueba[3];
    [SerializeField] private Image show;
    [SerializeField] private Image timer;
    [SerializeField] private GameObject Loose;
    [SerializeField] private Canvas win;
    [SerializeField] private float speed = 10;
    //int i = 0;

    private bool _stop = true;
    private float _time;
    private float _actualTime;
    private float _actualfil;
    private Renderer _renderer;
    private int _selector;

    private void Start()
    {
        _stop = true;
    }
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
        float fill = _actualTime / 10;
        fill = (1 - fill) + 0;
        timer.fillAmount = fill;
        speed = 10;
        if (_actualTime <= 10)
        {
            _actualfil = Time.time + _time;
            Win();
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
        this.transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnBecameInvisible()
    {
        StopCoroutine(Salida());
        //this.gameObject.SetActive(false);
        CloneClient();
        _actualTime = 11;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

            Debug.Log("enr");
            _time = _actualTime;
            this.transform.Translate(0, 0, 0);
            foreach (var ing in ingred)
            {
                ing.orden = show.gameObject;
            }
            ChoseIngredients();
            _stop = false;
    }

    private void CloneClient()
    {
        timer.fillAmount = 0;
        show.material = null;
        this.transform.position = new Vector3(-15, 5, 5);
        if (!this.gameObject.scene.isLoaded) return;
        Instantiate(this.gameObject);
        MoveX();
    }

    private void Win()
    {
        if (win.gameObject.activeInHierarchy == true || Loose.activeInHierarchy == true)
        {
            speed = 0.08f;
            timer.fillAmount = _actualfil;
            StartCoroutine(Salida());
        }
    }

    private IEnumerator Salida()
    {
        while (true)
        {
            MoveX();
            _time = _actualTime;
            yield return null;
        }
    }
}
