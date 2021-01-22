using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpedometerController : MonoBehaviour
{
    public Image fill;
    private float speed;

    // Update is called once per frame
    void Update()
    {
        speed = CarInstance.SharedInstance.speed;
        fill.fillAmount = (speed / 30) * 0.5f;
        Debug.LogFormat("Speed: {0}", speed);
    }
}
