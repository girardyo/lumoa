using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Callable

    public static void LaunchAudio(AudioSource audio)
    {
        LaunchAudioOrchestration(audio);
    }

    #endregion





    #region Orchestration

    private static void LaunchAudioOrchestration(AudioSource audio)
    {
        StartAudio(audio);
    }

    #endregion





    #region Tools

    private static void StartAudio(AudioSource audio)
    {
        audio.Play(0);
    }

    #endregion

}
