using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{
    public Text mins;
    public Text segs;
    public float Tiemp;
    public GameObject gameOver;
    [SerializeField] public GameObject canvasWin;
   
  

    
    void Update()
    {
        if (Tiemp>0)
        {
            Tiemp -= Time.deltaTime;  
        }
        else
        {
            Tiemp = 0;
        }
        
        float minutos = Mathf.FloorToInt(Tiemp / 60);
        float segundos = Mathf.FloorToInt(Tiemp % 60);

        if (minutos == 0)
            mins.text = "0:";
        else
        {
            mins.text = "" + minutos.ToString("") + ":";
        }
        
        if (segundos == 0)
            segs.text = "0";
        else
        {
            segs.text = "" + segundos.ToString("") ;
        }


        if (Tiemp == 0)
        {
            Time.timeScale = 0f;
            gameOver.gameObject.SetActive(true);
            canvasWin.SetActive(false);
        }
        
    }
    
}