using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootIfGrabbed : MonoBehaviour
{
    private SimpleShoot simpleShoot;
    private OVRGrabbable oVRGrabbable;
    public OVRInput.Button shootingButton;

    public int maxNumberOfBullet = 10;
    public Text bulletText;

    public AudioClip audioClip;

    private void Start()
    {
        simpleShoot = GetComponent<SimpleShoot>();
        oVRGrabbable = GetComponent<OVRGrabbable>();
        bulletText.text = maxNumberOfBullet.ToString();
    }

    private void Update()
    {
        if (oVRGrabbable.isGrabbed && OVRInput.GetDown(shootingButton, oVRGrabbable.grabbedBy.GetController()) && maxNumberOfBullet>0)
        {
            VibrtationManager.singleton.VibrationMan(audioClip, oVRGrabbable.grabbedBy.GetController());
           //VRInput.SetControllerVibration(.5f, .5f, oVRGrabbable.grabbedBy.GetController());
            GetComponent<AudioSource>().PlayOneShot(audioClip);
            simpleShoot.TriggerShoot();
            maxNumberOfBullet--;
            bulletText.text = maxNumberOfBullet.ToString();
           
        }
    }
}
