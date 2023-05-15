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
    [SerializeField] public  Image[] show = new Image[3];
    [SerializeField] private Image timer;
    [SerializeField] private GameObject Loose;
    [SerializeField] private Canvas win;
    [SerializeField] private float speed = 10;
    [SerializeField] private Validation bento;
    [SerializeField] public Box[] boxes = new Box[3];

    //int i = 0;

    private float _time;
    private float _actualTime;
    private Renderer _renderer;
    private int _selector;
    

    private void Start()
    {
        bento.Reasingnar();
        MoveX();
    }
    void Update()
    {
        MoveX();
    }

    private void ChoseIngredients()
    {
        foreach (var sho in show)
        {
            _selector = Random.Range(0, ingredients.Length);
            _renderer = ingredients[_selector].GetComponent<Renderer>();
            sho.tag = ingredients[_selector].tag;
            sho.material = _renderer.material;
        }
    }

    IEnumerator ShowCanva()
    {
        speed = 10;
        yield return new WaitForSeconds(1.2f);
        Loose.SetActive(false);
    }

    private void MoveX()
    {
        this.transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnBecameInvisible()
    {
        CloneClient();
        bento.canVerify = true;
        bento.canValidate = true;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "order")
        {
            _time = Time.time;
            speed = 0;
            for(int i = 0; i<ingred.Length-1; i++)
            {
                ingred[i].orden = show[i].gameObject;
            }
            bento.canValidate = true;
            /*foreach (var zone in boxes)
            {
                zone.canDes = true;
            }
            foreach (var area in boxes)
            {
                area.tag = "DropArea";
            }*/
            ChoseIngredients();
        }
    }

    private void CloneClient()
    {
        timer.fillAmount = 0;
        foreach (var sho in show)
        {
            sho.material = null;
        }
        this.transform.position = new Vector3(-15, 5, 5);
        if (!this.gameObject.scene.isLoaded) return;
        Instantiate(this.gameObject);
    }

    private void Win()
    {
        if (win.gameObject.activeInHierarchy == true || Loose.activeInHierarchy == true)
        {
            speed = 10;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        _actualTime = Time.time - _time;
        float fill = _actualTime / 10;
        fill = (1 - fill) + 0;
        timer.fillAmount = fill;
        if (_actualTime <= 10)
        {
            Win();
        }
        else
        {
            Loose.SetActive(true);
            StartCoroutine(ShowCanva());
            /*foreach (var zone in boxes)
            {
                zone.canDes = true;
            }
            foreach (var area in boxes)
            {
                area.tag = "DropArea";
            }*/
        }
    }


}
