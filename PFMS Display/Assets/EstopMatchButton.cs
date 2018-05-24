using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstopMatchButton : MonoBehaviour {

    private Button childButton;

    public PFMSConnection pfms;

	// Use this for initialization
	void Start () {
        if (pfms == null)
        {
            Debug.LogError("PFMS Not set for EStopMatchButton Controller!");
            gameObject.SetActive(false);
        }
        childButton = GetComponentInChildren<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	    childButton.gameObject.SetActive(pfms.jsonPayload.CurrentGamePhase != "PREMATCH" && pfms.jsonPayload.CurrentGamePhase != "POSTMATCH" && pfms.jsonPayload.CurrentGamePhase != "" && pfms.estopView);
    }
}
