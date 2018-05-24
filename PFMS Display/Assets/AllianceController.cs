using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllianceController : MonoBehaviour {

    public List<AllianceStation> allianceStations;
    public bool isRedAlliance = false;
    public GameObject AllianceStationPrefab;
    public PFMSConnection pfms;

    public List<DriverStation> previousDSInfo;

	// Use this for initialization
	void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
        List<DriverStation> currentDSInfo = (isRedAlliance ? pfms.jsonPayload.RedAlliance : pfms.jsonPayload.BlueAlliance);
        if (currentDSInfo == null) return;
        if (ListsEqual(currentDSInfo, previousDSInfo)) return;

        
        Debug.Log("Regenerating " + (isRedAlliance ? "Red" : "Blue") + " Alliance Section");
        previousDSInfo = currentDSInfo;
        
        //Debug.Log(currentDSInfo.ToArray()[0] + " " + previousDSInfo.ToArray()[0]);
        foreach (AllianceStation allSta in allianceStations)
        {
            Destroy(allSta.gameObject);
        }
        allianceStations.Clear();

        foreach (DriverStation ds in currentDSInfo)
        {
            GameObject newAllStat = Instantiate(AllianceStationPrefab, this.gameObject.transform);
            newAllStat.GetComponent<AllianceStation>().setup(isRedAlliance, ds.AllianceStationID);
            allianceStations.Add(newAllStat.GetComponent<AllianceStation>());
        }
	}

    private static bool ListsEqual(List<DriverStation> list1, List<DriverStation> list2)
    {
        if (list1 == null || list2 == null) return false;
        if (list1.Count != list2.Count) return false;

        for(int i = 0; i < list1.Count; i++)
        {
            if (list1[i].TeamNumber != list2[i].TeamNumber) return false;
        }

        return true;
    }
}
