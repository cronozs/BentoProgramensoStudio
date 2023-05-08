using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseAndPlay : MonoBehaviour
{

    [SerializeField] public GameObject PauseMenu;
    
    public void PauseGame ()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame ()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void HomeMenu ()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    
}
