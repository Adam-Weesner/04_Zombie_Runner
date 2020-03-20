using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private Light myLight = null;
    [SerializeField] private float lightDecay = 0.1f;
    [SerializeField] private float angleDecay = 3.0f;
    [SerializeField] private float minAngle = 40f;
    private float maxIntensity = 0.0f;
    private float maxAngle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        maxIntensity = myLight.intensity;
        maxAngle = myLight.spotAngle;
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle > minAngle)
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    public void RestoreLightIntensity(float restoreIntensity)
    {
        myLight.intensity = Mathf.Clamp(myLight.intensity + restoreIntensity, 0, maxIntensity);
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = Mathf.Clamp(myLight.spotAngle + restoreAngle, 0, maxAngle);
    }
}
