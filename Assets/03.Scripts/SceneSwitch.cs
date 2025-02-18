using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : Switch
{
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private int SceneNumber;

    private bool isStay = false;
    private bool isDown = false;
    
    private FadeEffect fadeEffect;

    private void Start()
    {
        fadeEffect = UIManager.Instance.fadeEffect;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isStay = true;
        if (collision.CompareTag("Player"))
            Toggle();
    }

    private void Update()
    {
        if (isDown) return;

        if (isStay && Input.GetKeyDown(keyCode))
        {
            isDown = true;
            SceneManager.LoadScene(SceneNumber);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isStay = false;
        if (collision.CompareTag("Player"))
            Toggle();
    }
}
