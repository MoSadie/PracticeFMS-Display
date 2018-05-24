using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotRadioDisplay : MonoBehaviour {

    private Image background;
    private AllianceStation allianceStation;

    public static Color defaultWhite = new Color(1, 1, 1, 100 / 255f);
    public static Color badRed = new Color(255, 0, 58f / 255f, 107f / 255f);
    public static Color goodGreen = new Color(76f / 255f, 175f / 255f, 80f / 255f, 99f / 255f);

    // Use this for initialization
    void Start()
    {
        background = GetComponent<Image>();
        allianceStation = GetComponentInParent<AllianceStation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (allianceStation.latestDSInfo != null)
        {
            background.color = (allianceStation.latestDSInfo.IsRobotRadioConnected ? goodGreen : badRed);
        }
        else
        {
            background.color = badRed;
        }
    }
}
