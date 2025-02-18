using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : Switch
{
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private int SceneNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Toggle();
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
            SceneManager.LoadScene(0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Toggle();
    }
}
