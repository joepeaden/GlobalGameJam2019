using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackFadeControl : MonoBehaviour
{
    public GameObject rainSpawner;
    public CutSceneManager csm;

    private float startTime;
    private AudioSource audioSource;
    private bool fadeOut;

    [Range(1,5)]
    public float fadeTime;

    private void Start()
    {
        startTime = Time.time;

        audioSource = rainSpawner.GetComponent<AudioSource>();
        audioSource.volume = 0.0f;
        audioSource.Play((ulong)0f);

        fadeOut = false;
    }

    void Update()
    {
        Color color = GetComponent<Image>().color;

        // Fade in timer
        if (fadeOut == false)
        {
            if (Time.time - startTime > fadeTime)
            {
                audioSource.volume = 1.0f;
                this.gameObject.SetActive(false);
            }

            GetComponent<Image>().color = new Color(color.r, color.g, color.b, 1 - ((Time.time - startTime) / fadeTime));
            audioSource.volume = (Time.time - startTime) / fadeTime;
        }

        // Fade out Timer
        if (fadeOut == true)
        {
            // Still fading
            if ((Time.time - startTime) / fadeTime < 1f)
            {
                GetComponent<Image>().color = new Color(color.r, color.g, color.b, (Time.time - startTime) / fadeTime);
            }
            // fading done
            else
                csm.LoadNextLevel();

        }
    }

    public void BeginFadeOut()
    {
        startTime = Time.time;
        fadeOut = true;
        this.gameObject.SetActive(true);
    }
}
