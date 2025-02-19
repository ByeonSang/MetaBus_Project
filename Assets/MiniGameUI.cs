using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameUI : MonoBehaviour
{
    [SerializeField] private GameObject gameLogic;
    public void GameStart()
    {
        transform.gameObject.SetActive(false);
        gameLogic.SetActive(true);
    }

    public void LobbyScene()
    {
        SceneManager.LoadScene(0);
    }
}
