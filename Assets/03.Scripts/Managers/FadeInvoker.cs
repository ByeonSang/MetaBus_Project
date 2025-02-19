using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInvoker : MonoBehaviour
{
    public FadeEffect fadeEffect;

    private void Start()
    {
        gameObject.SetActive(true);
        fadeEffect = GetComponentInChildren<FadeEffect>();
        Debug.Log(fadeEffect);
        if (fadeEffect != null)
            fadeEffect.StartFade(1f, 0f);
    }
}
