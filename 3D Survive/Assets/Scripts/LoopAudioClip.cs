using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAudioClip : MonoBehaviour
{
    public AudioClip audioClip;
    public double loopStart;
    public double loopDuration;
    public double offset;
    //public int loopCount;

    private AudioSource audioSource;
    private double nextLoopTime;
    //private int currentLoopCount;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.loop = false;

        // Set the start time for the first loop
        nextLoopTime = AudioSettings.dspTime + loopStart + offset;
        //currentLoopCount = 0;
    }

    void Update()
    {
        // Check if it's time for the next loop
        if (AudioSettings.dspTime >= nextLoopTime)
        {
            // Schedule the next loop
            
            audioSource.PlayScheduled(nextLoopTime);
            nextLoopTime += loopDuration;

            // Increment the loop count
            //currentLoopCount++;

            //// Check if we've reached the maximum loop count
            //if (currentLoopCount >= loopCount)
            //{
            //    // Stop the audio source
            //    audioSource.Stop();
            //}
        }
    }
}
