using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class IngredientList : MonoBehaviour
{
    [SerializeField] private GameObject[] ingredients;
    [SerializeField] private Sprite[] imagenesShow;
    [SerializeField] private Drag_prueba[] ingred;
    [SerializeField] public  Image[] show;
    [SerializeField] private Image timer;
    [SerializeField] private GameObject Loose;
    [SerializeField] private Canvas win;
    [SerializeField] private float speed;
    [SerializeField] private float monaSpeed;
    [SerializeField] private Validation bento;
    [SerializeField] public Box[] boxes = new Box[3];
    [SerializeField] private float canvaTime;
    [SerializeField] private int timeOfOrder;
    public float fill = 0;
    
    

    //int i = 0;

    private float _time;
    private float _actualTime;
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
            sho.tag = ingredients[_selector].tag;
            sho.sprite = imagenesShow[_selector];
        }
    }

    IEnumerator ShowCanva()
    {
        speed = monaSpeed;
        yield return new WaitForSeconds(canvaTime);
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
            int j = 0;
            for(int i = 0; i<ingred.Length-1; i++)
            {
                ingred[i].orden = show[j].gameObject;
                if(j >= 2)
                {
                    j = 2;
                }
            }
            foreach (var area in boxes)
            {
                var col = area.GetComponent<BoxCollider>();
                col.enabled = true;
                area.tag = "DropArea";
            }
            ChoseIngredients();
        }
    }

    private void CloneClient()
    {
        timer.fillAmount = 0;
        foreach (var sho in show)
        {
            sho.sprite = null;
        }
        this.transform.position = new Vector3(-15, 5, 5);
        if (!this.gameObject.scene.isLoaded) return;
        Instantiate(this.gameObject);
    }

    private void Win()
    {
        if (win.gameObject.activeInHierarchy == true || Loose.activeInHierarchy == true)
        {
            speed = monaSpeed;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        _actualTime = Time.time - _time;
        fill = _actualTime / timeOfOrder;
        fill = (1 - fill) + 0;
        timer.fillAmount = fill;
        if (_actualTime <= timeOfOrder)
        {
            Win();
        }
        else
        {
            Loose.SetActive(true);
            StartCoroutine(ShowCanva());
           
        }
    }


}
