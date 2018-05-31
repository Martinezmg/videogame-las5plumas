using UnityEngine.Audio;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ClipsContainer : MonoBehaviour
{
    private AudioSource clipOutput;

    public Audio[] clips;

    private void Start()
    {
        clipOutput = GetComponent<AudioSource>();
    }

    public void PutClip(int index)
    {
        if (index >= clips.Length)
        {
            return;
        }

        Audio a = clips[index];

        clipOutput.clip = a.clip;
        clipOutput.volume = a.volume;

        clipOutput.Play();
    }
}
