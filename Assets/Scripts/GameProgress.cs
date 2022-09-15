using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameProgress : MonoBehaviour
{
    // Variables
    private float journeyLenght = 10000f;
    private float progressSpeed = 2f;
    private float remainingJourney = 0f;
    public UIDocument SceneUI;
    private Label JourneyLabel;
    private Label pauseLabel;
    private Label winLabel;
    private Label timeLabel;
    private Label finalTimeLabel;
    private Button restartButton;
    private Button exitButton;

    private bool pauseState = false;
    private float timeStart = 0;
    private float finalTime;


    // Start is called before the first frame update
    void Start()
    {
        // Find the UI elemets
        VisualElement root = SceneUI.rootVisualElement;
        JourneyLabel = root.Q<Label>("JourneyAmount");
        pauseLabel = root.Q<Label>("pauseText");
        winLabel = root.Q<Label>("winningText");
        exitButton = root.Q<Button>("exitGameScene");
        restartButton = root.Q<Button>("restartGame");
        timeLabel = root.Q<Label>("TimeAmount");
        finalTimeLabel = root.Q<Label>("finalTimeLabel");

        // Hides the buttons so they dont show up until paused / game over
        exitButton.visible = false;
        restartButton.visible = false;
        pauseLabel.visible = false;
        winLabel.visible = false;
        finalTimeLabel.visible = false;
        pauseState = false;
        timeLabel.visible = false;



        // does things when buttons are pressed
        restartButton.clickable.clicked += () =>
        {
            Debug.Log("Restart Button Clicked");
            SceneManager.LoadScene(1);
            pauseState = false;
            ResumeGame();
            journeyLenght = 10000f;

        };
        exitButton.clickable.clicked += () =>
        {
            Debug.Log("Exit Button Clicked");
            Application.Quit();
        };
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(remainingJourney);

        timeStart += Time.deltaTime;
        timeLabel.text = timeStart.ToString();

        if (Input.GetButtonDown("Cancel")) // toggles the pause state bool based on pressing esc
        {
            pauseState ^= true;
        }

        if(pauseState == true)
        {
            PauseGame();
        }
        if (pauseState == false)
        {
            ResumeGame();

        }

        if (remainingJourney <= 0)
        {
            GameOver();
        }
        

    }

    private void FixedUpdate()
    {
        JourneyTracker();
    }

    void JourneyTracker()
    {
        remainingJourney = (journeyLenght -= progressSpeed);
        JourneyLabel.text = "Lightyears Remaining: "+remainingJourney.ToString();
        
    }

    public void ChangeSpeedCounter(bool speedSwitch)
    {
        if(speedSwitch == true) { progressSpeed = progressSpeed * 2; }
        if (speedSwitch == false) { progressSpeed = progressSpeed / 2; }
    }


    void PauseGame() // brings up pause menu
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0;
        exitButton.visible = true;
        restartButton.visible = true;
        pauseLabel.visible = true;
    }
    void ResumeGame() // resumes game
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1;
        exitButton.visible = false;
        restartButton.visible = false;
        pauseLabel.visible = false;
    }

    void GameOver() // brings up pause menu
    {
        Debug.Log("Game Complete");
        Time.timeScale = 0;
        exitButton.visible = true;
        restartButton.visible = true;
        winLabel.visible = true;
        finalTimeLabel.visible = true;
        finalTime = ((journeyLenght - timeStart)/journeyLenght);
        finalTimeLabel.text = "Congrats You finished "+ finalTime+" % faster!";
    }

}
