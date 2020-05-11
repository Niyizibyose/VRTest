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

            simpleShoot.TriggerShoot();
            maxNumberOfBullet--;
            bulletText.text = maxNumberOfBullet.ToString();
           
        }
    }
}
