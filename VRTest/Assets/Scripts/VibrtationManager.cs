using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrtationManager : MonoBehaviour
{
    public static VibrtationManager singleton;
    // Start is called before the first frame update
    void Start()
    {
        if (singleton && singleton != this)
        {
            Destroy(this);
        }
        else
        {
            singleton = this;
        }
        
    }

 public void VibrationMan (AudioClip vibeAudio , OVRInput.Controller controller)
    {
        OVRHapticsClip clip = new OVRHapticsClip(vibeAudio);

        if (controller == OVRInput.Controller.LTouch)
        {
            OVRHaptics.LeftChannel.Preempt(clip);
        }

        else if (controller == OVRInput.Controller.RTouch)
        {
            OVRHaptics.RightChannel.Preempt(clip);
        }
               
    }


    public void VibrationMan(int iteration, int frequency , OVRInput.Controller controller, int strength)
    {
        OVRHapticsClip clip = new OVRHapticsClip();

        for (int i=0; i<iteration; i++)
        {
            clip.WriteSample(i % frequency == 0 ? (byte)strength : (byte)0);
        }

        if (controller == OVRInput.Controller.LTouch)
        {
            OVRHaptics.LeftChannel.Preempt(clip);
        }

        else if (controller == OVRInput.Controller.RTouch)
        {
            OVRHaptics.RightChannel.Preempt(clip);
        }

    }
}
