using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private int switchNumber = 0;
    public GameObject target;
    private ISwitchable switchable;

    private void Awake()
    {
        target.TryGetComponent<ISwitchable>(out switchable);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            Toggle();   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Toggle();
    }

    public void Toggle()
    {
        if (switchable.IsActive)
        {
            switchable.Deactivate();
        }
        else
        {
            switchable.Activate(switchNumber);
        }
    }
}
