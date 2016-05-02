using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextStateManager : MonoBehaviour {

    private ActivateTextAtLine activateTextAtLine;

    //setup variables
    public TextAsset stateFile;
    public string[] stateLines;
    public string[] tempStateNumbersStr;
    public int[] tempStateNumbers;

    public Dictionary<int, int[]> stateDict = new Dictionary<int, int[]>();
    public int currentState;

	// Use this for initialization
	void Start () {
        activateTextAtLine = GetComponent<ActivateTextAtLine>();

        if (stateFile != null)
        {
            stateLines = (stateFile.text.Split('\n'));
        }

        for (int i = 0; i < stateLines.Length; i++)
        {
            tempStateNumbersStr = (stateLines[i].Split(' '));
            tempStateNumbers = new int[3];
            for (int j = 0; j < tempStateNumbersStr.Length; j++)
            {
                if (j == 0) { continue; }
                tempStateNumbers[j - 1] = int.Parse(tempStateNumbersStr[j]);
            }
            stateDict.Add(int.Parse(tempStateNumbersStr[0]), tempStateNumbers);
        }

        //foreach (KeyValuePair<int, int[]> k in stateDict)
        //{
            //Debug.Log(k.Key);
            //Debug.Log(k.Value);
        //}

        currentState = 0;
    }

    public void setState()
    {
        activateTextAtLine.startLine = stateDict[currentState][1];
        activateTextAtLine.endLine = stateDict[currentState][2];
        changeState();
    }

    public void changeState()
    {
        currentState = stateDict[currentState][0];
        Debug.Log("BEEP");
        Debug.Log(currentState);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
