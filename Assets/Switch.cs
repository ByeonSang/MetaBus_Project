using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private int switchNumber = 0;
    public GameObject target;
    protected ISwitchable switchable;

    private void Awake()
    {
        if (!target.TryGetComponent<ISwitchable>(out switchable))
            Debug.LogError("switchable NullReference");
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
