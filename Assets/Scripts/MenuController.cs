using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public void LoadLvlScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public Button playButton; 
    public Button playButton2;

    void Update()
    {
        // Botón A del control Xbox
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            Debug.Log("Botón A presionado 🎮");
            playButton.onClick.Invoke(); 
            playButton2.onClick.Invoke();
        }
    }

}

