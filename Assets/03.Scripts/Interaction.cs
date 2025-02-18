using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interaction : MonoBehaviour, ISwitchable
{
    [SerializeField] private string[] interactionInfo =
    {
        "StackZone 입장하기"
    };

    public bool IsActive { get; private set; }

    private TextMeshProUGUI[] textPro;

    private void Start()
    {
        textPro = GetComponentsInChildren<TextMeshProUGUI>();
        IsActive = false;
        gameObject.SetActive(false);
    }

    public void Activate(int idx)
    {
        IsActive = true;
        gameObject.SetActive(true);
        textPro[1].text = interactionInfo[idx];
    }

    public void Deactivate()
    {
        IsActive = false;
        gameObject.SetActive(false);
    }
}
