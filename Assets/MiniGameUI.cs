using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameUI : MonoBehaviour
{
    const string key = "MaxScore";

    [SerializeField] private GameObject gameLogic;
    private Stack stack;

    [SerializeField] private GameObject menuUI; // �Ʒ� �޴��� ���� ���� ��ü
    [SerializeField] private GameObject InGameUI;
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject scoreMenuUI;

    [Header("TextMeshProUGUI")]
    [SerializeField] private TextMeshProUGUI scoreMenuTxt;
    [SerializeField] private TextMeshProUGUI InGameScoreTxt;

    public int CurrentScore { get; set; }
    public int MaxScore { get; set; }

    private void Awake()
    {
        stack = gameLogic.GetComponentInChildren<Stack>();

        if (PlayerPrefs.HasKey(key))
            MaxScore = PlayerPrefs.GetInt(key);
        else
            MaxScore = 0;
    }

    private void Start()
    {
        mainMenuUI.SetActive(true);
        scoreMenuUI.SetActive(false);
        InGameUI.SetActive(false);
    }

    public void GameStart()
    {
        menuUI.SetActive(false);
        gameLogic.SetActive(true);
        InGameUI.SetActive(true);
    }

    public void LobbyScene()
    {
        SceneManager.LoadScene(0);
    }

    public void MoveScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void GameOver()
    {
        gameLogic.SetActive(false);
        InGameUI.SetActive(false);

        if (CurrentScore > MaxScore)
        {
            MaxScore = CurrentScore;
            PlayerPrefs.SetInt(key, MaxScore);
        }

        menuUI.SetActive(true);
        mainMenuUI.SetActive(false);
        scoreMenuUI.SetActive(true);

        SetScoreBoard();
    }

    private void SetScoreBoard()
    {
        scoreMenuTxt.text = string.Format("��������: {0}\n�ְ�����: {1}", CurrentScore, MaxScore);
    }

    public void SetInGameScore()
    {
        InGameScoreTxt.text = string.Format("��������: {0}\n���� �ְ�����: {1}", CurrentScore, MaxScore);
    }
}
