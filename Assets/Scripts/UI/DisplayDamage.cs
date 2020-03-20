using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDamage : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DisplayBloodSplatter());
    }

    private IEnumerator DisplayBloodSplatter()
    {
        float clipLength = GetComponent<Animation>().clip.length;
        yield return new WaitForSeconds(clipLength);
        gameObject.SetActive(false);
    }
}
