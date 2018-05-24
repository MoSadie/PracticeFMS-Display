using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstopStatusText : MonoBehaviour {

    public PFMSConnection pfms;
    private Text text;

    public void Start()
    {
        text = GetComponent<Text>();        
    }
    // Update is called once per frame
    void Update () {
        if (pfms.estopView)
            text.text = "View: EStop";
        else
            text.text = "View: Status";
	}
}
