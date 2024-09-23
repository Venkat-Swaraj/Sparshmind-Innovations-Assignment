using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITween : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip Clip;
    private void Start()
    {
        // Popup();
    }

    public void Popup()
    {
        AudioSource.clip = Clip;
        
        LeanTween.scale(this.gameObject, new Vector3(1.25f, 1.25f, 1.25f), 2f).setDelay(.5f)
            .setEase(LeanTweenType.easeOutElastic);
        AudioSource.Play();
        LeanTween.scale(this.gameObject, new Vector3(1f, 1f, 1f), 2f).setDelay(1f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(Popdown);
        
    }

    public void Popdown()
    {
        LeanTween.scale(this.gameObject, new Vector3(0f, 0f, 0f), .5f).setEase(LeanTweenType.easeOutCirc);
    }
}
