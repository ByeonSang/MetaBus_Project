using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour, ISwitchable
{
    public bool IsActive { get; private set; }

    private void Awake()
    {
        IsActive = false;
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        IsActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        IsActive = false;
        gameObject.SetActive(false);
    }
}
