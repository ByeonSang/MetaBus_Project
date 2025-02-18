using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingleTon<UIManager>
{
    public FadeEffect fadeEffect;

    private void Start()
    {
        fadeEffect.StartFade(1f, 0f);
    }
}
