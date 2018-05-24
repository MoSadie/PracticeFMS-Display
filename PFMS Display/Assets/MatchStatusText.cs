using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchStatusText : MonoBehaviour {

    public PFMSConnection pfms;
    private Text text;

	// Use this for initialization
	void Start () {
        if (pfms == null) gameObject.SetActive(false);
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (pfms.PFMSConnected)
        {
            text.text = "Current Status: Match Phase: " + pfms.jsonPayload.CurrentGamePhase + " Time Left: " + pfms.jsonPayload.TimeLeftInPhase; 
        } else
        {
            text.text = "Current Status: Practice FMS Disconnected";
        }
	}
}
