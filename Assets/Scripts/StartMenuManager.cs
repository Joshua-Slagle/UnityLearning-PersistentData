using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public TMP_Text bestScoreText;
    public TMP_InputField playerNameField;
    // Start is called before the first frame update
    void Start()
    {
        this.bestScoreText.text = GameData.Instance.PrintHighScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonPressed()
    {
        GameData.Instance.currentPlayerName = this.playerNameField.text;
        SceneManager.LoadScene("main");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        GameData.Instance.SavePlayerData();
    } 
}
