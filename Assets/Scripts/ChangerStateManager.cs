using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ChangerStateManager : MonoBehaviour {

    //ugly variables to make the rudamentary code work. 
    //To be removed when real system is implemented.
    public string changeTextStateOf;
    public int changeTextStateTo;

    public class changerSubState
    {
        public string objectName;
        public int textState;
        public int changerState;
        public int worldState;
    }

    //setup variables
    public TextAsset changerStateFile;
    public string[] tempChangerStatesArray;
    public string[] tempChangerSubStateArray;

    public Dictionary<int, changerSubState[]> changerStateDict = new Dictionary<int, changerSubState[]>();

    // Use this for initialization
    void Start () {

        tempChangerStatesArray = Regex.Split(changerStateFile.text, @"/(?:\n|\r\n){2}");
        for (int i = 0; i < tempChangerStatesArray.Length; i++)
        {
            Debug.Log(tempChangerStatesArray[i]);
            tempChangerSubStateArray = Regex.Split(tempChangerStatesArray[i], "\n");

            for (int j = 0; j < tempChangerSubStateArray.Length; j++)
            {
                //if (tempChangerSubStateArray[j] == "" || tempChangerSubStateArray[j] == "\n" || tempChangerSubStateArray[j] == " ") { continue; }
                //Debug.Log(tempChangerSubStateArray[j]);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //obsolete function to be fixed
    public void changeTextStateOfObj()
    {
        if (changeTextStateOf != null && changeTextStateOf != "")
        {
            GameObject.Find(changeTextStateOf).GetComponent<TextStateManager>().currentState = changeTextStateTo;
        }
    }
}
