using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button start;
    public Button exit;
    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(Starting);
        exit.onClick.AddListener(Exiting);
        
    }

    private void Starting()
    {
        SceneManager.LoadScene(1);
    }

    private void Exiting()
    {
        #if UNITY_EDITOR
        // Quitting in Unity Editor:
        UnityEditor.EditorApplication.isPlaying = false; 
        #else 
        // Quitting in all other builds: 
        Application.Quit();
        #endif

    }

}
