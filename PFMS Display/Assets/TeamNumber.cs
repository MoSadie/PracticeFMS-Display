using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamNumber : MonoBehaviour {

    private Text childText;
    private AllianceStation allianceStation;

	// Use this for initialization
	void Start () {
        childText = GetComponentInChildren<Text>();
        allianceStation = GetComponentInParent<AllianceStation>();
	}
	
	// Update is called once per frame
	void Update () {
		if (allianceStation.latestDSInfo != null)
        {
            childText.text = (allianceStation.isRedAlliance ? "Red" : "Blue") + " " + allianceStation.stationId + ": " + allianceStation.latestDSInfo.TeamNumber;
        } else
        {
            childText.text = (allianceStation.isRedAlliance ? "Red" : "Blue") + " X: XXXX";
        }
	}
}
