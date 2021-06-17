using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopKranAudio : MonoBehaviour
{
    //[SerializeField] private AudioClip sound;
    [SerializeField] private AudioSource audioSource;
    private JointAction action;

    void Start()
    {
        action = GetComponent<JointAction>() ?? throw new System.NullReferenceException("Joint behaviour isn't found");
        JointAction.onPointerButtonClick += switchAudioSource;
    }

    private void switchAudioSource()
    {
        if (action._turnedOn)
            LoopSoundOn();
        else
            LoopSoundOff();
    }

    private void LoopSoundOn()
    {
        Debug.Log("Звук включился");
        audioSource.mute = false;
    }
    private void LoopSoundOff()
    {
        Debug.Log("Звук ВЫКЛ");
        audioSource.mute = true;

    }
}
