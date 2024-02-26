using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchTime : MonoBehaviour
{
    private float normalTimeScale = 1.0f;
    private float slowedTimeScale = 0.25f;
    private float startTime;
    private float witchTimeDuration = 0f; 

    void Start()
    {
        StartCoroutine(ActivateWitchTime());
    }

    IEnumerator ActivateWitchTime()
    {
        AudioClip witchTimeAudioClip = Resources.Load<AudioClip>("witchTime"); 
        AudioManager.instance.PlayAudio(witchTimeAudioClip, "WitchTimeAudio", false, 1.0f);
        witchTimeDuration = witchTimeAudioClip.length;
        Time.timeScale = slowedTimeScale;
        startTime = Time.time;
        while (Time.time - startTime < witchTimeDuration)
        {
            yield return null;
        }
        Time.timeScale = normalTimeScale;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
          
            Time.timeScale = slowedTimeScale;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Time.timeScale = normalTimeScale;
        }
    }
}
