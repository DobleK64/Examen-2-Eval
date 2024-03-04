using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
//public AudioClip witchAudio;
//void Update()
//{
//    if (Input.GetKeyDown(KeyCode.Mouse1))
//    {
//        StartCoroutine(SlowDown());

//    }
//}
//IEnumerator SlowDown()
//{
//    Time.timeScale = 0.25f;
//    AudioSource src = AudioManager.instance.PayAudio(witchAudio, "witch");

//    while (src.isPlaying)
//        yield return null;

//    Time.timeScale = 1f;
//}
public class WitchTime : MonoBehaviour
{
    private float normalTimeScale = 1.0f;
    private float slowedTimeScale = 0.25f;
    private float startTime;
    private float witchTimeDuration = 0f;
    public AudioClip witchTimeAudioClip;

    void Start()
    {
        
    }

    IEnumerator ActivateWitchTime()
    {
    
        AudioSource source = AudioManager.instance.PlayAudio(witchTimeAudioClip, "WitchTimeAudio", false, 1.0f);
        witchTimeDuration = witchTimeAudioClip.length;
        Time.timeScale = slowedTimeScale;
        startTime = Time.time;
        while (source && source.isPlaying)
        {
            yield return null;
        }
        Time.timeScale = normalTimeScale;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(ActivateWitchTime());
            Time.timeScale = slowedTimeScale;
        }
       
    }
}
