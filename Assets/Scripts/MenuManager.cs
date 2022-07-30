using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public InputField input;
    public string name;
    public TextMeshProUGUI currentName;
    public TextMeshProUGUI currentHighScore;
    public TextMeshProUGUI currentHighScoreName;

    // Start is called before the first frame update
    void Start()
    {
        currentName.text = "Current user: " + DPManager.Instance.playerName;
        currentHighScore.text = DPManager.Instance.highScore.ToString();
        currentHighScoreName.text = "High Score (" + DPManager.Instance.highScorePlayer + "):";

    }



    public void Update()
    {
        currentName.text = "Current user: " + DPManager.Instance.playerName;
    }

    public void ReadInputText()
    {
        
        DPManager.Instance.playerName = input.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        DPManager.Instance.SaveDetails();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
