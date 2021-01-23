using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpedometerController : MonoBehaviour
{
    public Image fill;
    private float speed;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        speed = CarInstance.SharedInstance.speed;
        fill.fillAmount = (speed / 30) * 0.5f;
        text.text = (Math.Truncate(speed) * 10).ToString();
    }
}
