using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class WeaponZoom : MonoBehaviour
    {
        [SerializeField] private float zoomMin = 28.0f;
        [SerializeField] private float zoomSpeed = 2.0f;
        [SerializeField] private float mouseSensitivityMin = 0.7f;
        private GameObject player = null;
        private float zoomMax;
        private float mouseSensitivityMax;
        private MouseLook mouseLook;

        private void Start()
        {
            zoomMax = Camera.main.fieldOfView;
            player = FindObjectOfType<Player>().gameObject;
            mouseLook = player.GetComponent<RigidbodyFirstPersonController>().mouseLook;
            mouseSensitivityMax = mouseLook.XSensitivity;
        }

        private void Update()
        {
            ChangeFOV();
            PlayWeaponADSAnim();
        }

        private void ChangeFOV()
        {
            if (CrossPlatformInputManager.GetButton("Fire2"))
            {
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomMin, Time.deltaTime * zoomSpeed);
                mouseLook.XSensitivity = Mathf.Lerp(mouseLook.XSensitivity, mouseSensitivityMin, Time.deltaTime * zoomSpeed);
                mouseLook.YSensitivity = Mathf.Lerp(mouseLook.YSensitivity, mouseSensitivityMin, Time.deltaTime * zoomSpeed);
            }
            else
            {
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomMax, Time.deltaTime * zoomSpeed);
                mouseLook.XSensitivity = Mathf.Lerp(mouseLook.XSensitivity, mouseSensitivityMax, Time.deltaTime * zoomSpeed);
                mouseLook.YSensitivity = Mathf.Lerp(mouseLook.YSensitivity, mouseSensitivityMax, Time.deltaTime * zoomSpeed);
            }
        }

        private void PlayWeaponADSAnim()
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire2"))
            {
                if (GetComponent<Animator>())
                {
                    GetComponent<Animator>().SetTrigger("IsZoomingIn");
                }
            }
            else if (CrossPlatformInputManager.GetButtonUp("Fire2"))
            {
                if (GetComponent<Animator>())
                {
                    GetComponent<Animator>().SetTrigger("IsZoomingOut");
                }
            }
        }
    }
}
