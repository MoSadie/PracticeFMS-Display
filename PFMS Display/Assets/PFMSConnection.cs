using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class PFMSConnection : MonoBehaviour {

    UnityWebRequest jsonRequest;

    public JSONPayload jsonPayload;
    public bool PFMSConnected = false;
    public bool estopView = true;

    public void toggleEstopView()
    {
        estopView = !estopView;
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(MainLoop());
	}

    public void EStopMatch()
    {
        UnityWebRequest estopRequest = new UnityWebRequest("http://10.0.100.5/PracticeFMS/estop/match");
        estopRequest.SendWebRequest();
    }

    public void EStopRobot(bool redAlliance, int stationID)
    {
        UnityWebRequest estopRequest = new UnityWebRequest("http://10.0.100.5/PracticeFMS/estop/" + (redAlliance ? "red" : "blue") + "/" + stationID);
        estopRequest.SendWebRequest();
    }
	
	IEnumerator MainLoop () {
        while (true)
        {
            jsonRequest = UnityWebRequest.Get("http://10.0.100.5/PracticeFMS/json");

            yield return jsonRequest.SendWebRequest();

            if (jsonRequest.isHttpError || jsonRequest.isNetworkError)
            {
                PFMSConnected = false;
                continue;
            }
            
            try
            {
                JSONPayload tmp_jsonPayload = JsonUtility.FromJson<JSONPayload>(jsonRequest.downloadHandler.text);
                if (tmp_jsonPayload.Version == null)
                {
                    PFMSConnected = false;
                    continue;
                }
                PFMSConnected = true;
                jsonPayload = tmp_jsonPayload;
            } catch (Exception e)
            {
                Debug.LogError("Exception: " + e.ToString());
                Debug.Log(jsonRequest.downloadHandler.text);
            }
        }
    }
}

[System.Serializable]
public class JSONPayload
{
    public string Version;
    public string CurrentGamePhase;
    public int TimeLeftInPhase;
    public string RedAllianceGameString;
    public string BlueAllianceGameString;
    public List<DriverStation> RedAlliance;
    public List<DriverStation> BlueAlliance;
}

[System.Serializable]
public class DriverStation
{
    public int TeamNumber;
    public string AllianceColor;
    public int AllianceStationID;
    public string RobotIP;
    public string RadioIP;
    public string DriverStationIP;
    public bool IsDriverStationConnected;
    public bool IsRoboRioConnected;
    public bool IsRobotRadioConnected;
    public bool EStop;
}
