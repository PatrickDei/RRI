using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//LAP COMPLETE SCRIPT

using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{

	public GameObject LapCompleteTrig;
	public GameObject HalfLapTrig;

	public GameObject MinuteDisplay;
	public GameObject SecondDisplay;
	public GameObject MilliDisplay;

	public GameObject LapTimeBox;

	void OnTriggerEnter()
	{
		Debug.Log(MilliDisplay.GetComponent<Text>().text.Substring(0, 1));
		if ((Int32.Parse(SecondDisplay.GetComponent<Text>().text.Trim('.', ':')) >= LapTimeManager.SecondCount
			&& Int32.Parse(MinuteDisplay.GetComponent<Text>().text.Trim(':', '.')) >= LapTimeManager.MinuteCount)
			|| Int32.Parse(MilliDisplay.GetComponent<Text>().text.Trim(',', ':', '.')) == 0)
		{
			if (LapTimeManager.SecondCount <= 9)
			{
				SecondDisplay.GetComponent<Text>().text = "0" + LapTimeManager.SecondCount + ".";
			}
			else
			{
				SecondDisplay.GetComponent<Text>().text = "" + LapTimeManager.SecondCount + ".";
			}

			if (LapTimeManager.MinuteCount <= 9)
			{
				MinuteDisplay.GetComponent<Text>().text = "0" + LapTimeManager.MinuteCount + ":";
			}
			else
			{
				MinuteDisplay.GetComponent<Text>().text = "" + LapTimeManager.MinuteCount + ":";
			}

			MilliDisplay.GetComponent<Text>().text = "" + LapTimeManager.MilliCount;
			Debug.Log(MilliDisplay.GetComponent<Text>().text);
		}

		LapTimeManager.MinuteCount = 0;
		LapTimeManager.SecondCount = 0;
		LapTimeManager.MilliCount = 0;

		HalfLapTrig.SetActive(true);
		LapCompleteTrig.SetActive(false);
	}

}