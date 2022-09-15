using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Variables
    private Button startButton;
    private Button exitButton;


    // Start is called before the first frame update
    void Start()
    {
        // LOOKS FOR THE THE UI DOC AS A COMPONENT (AS OPPOSED TO SETTING IT AS A VARIABLE)
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        // QUERIES THE UI DOCUMENT FOR THESE BUTTONS
        startButton = root.Q<Button>("startbutton");
        exitButton = root.Q<Button>("exitbutton");
        // ACT ON BUTTON PRESS
        startButton.clickable.clicked += () =>
        {
            Debug.Log("Start Button Clicked");
            SceneManager.LoadScene(1);
        };
        exitButton.clickable.clicked += () =>
        {
            Debug.Log("Exit Button Clicked");
            Application.Quit();
        };

    }

    
}
