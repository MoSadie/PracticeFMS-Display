using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllianceStation : MonoBehaviour {

    public bool isRedAlliance = false;
    public int stationId = 0;
    private PFMSConnection pfms;
    public DriverStation latestDSInfo;
    public GameObject Row1;
    public GameObject Row2;
    public GameObject Row3;

    public void Start()
    {
        pfms = GameObject.FindGameObjectWithTag("GameController").GetComponent<PFMSConnection>();
    }

    // Use this for initialization
    public void setup (bool isRedAlliance, int stationId) {
        this.isRedAlliance = isRedAlliance;
        this.stationId = stationId;
	}

    public void Update()
    {
        Row3.SetActive(pfms.estopView && (latestDSInfo.TeamNumber != 0 ? !latestDSInfo.EStop : false));

        if (isRedAlliance)
        {
            if (pfms.jsonPayload.RedAlliance.Count >= stationId)
            {
                latestDSInfo = pfms.jsonPayload.RedAlliance[stationId - 1];
            }
        } else
        {
            if (pfms.jsonPayload.BlueAlliance.Count >= stationId)
            {
                latestDSInfo = pfms.jsonPayload.BlueAlliance[stationId - 1];
            }
        }
    }

    public void estopRobot()
    {
        pfms.EStopRobot(isRedAlliance, stationId);
    }
}
