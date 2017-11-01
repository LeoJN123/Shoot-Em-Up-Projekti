using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomAudio
{
    public static class CustomAudio
    {

        public static void PlayOneShotRandomPitch(AudioSource aS, AudioClip aC, float pitchAmount)
        {
            float oP = aS.pitch;
            float nP = aS.pitch + Random.Range(-pitchAmount, pitchAmount);
            aS.PlayOneShot(aC);
            aS.pitch = oP;
        }


    }
}
