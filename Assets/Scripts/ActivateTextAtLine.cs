﻿using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;

    public bool destroyWhenActivated;

	// Use this for initialization
	void Start () {
        theTextBox = FindObjectOfType<TextBoxManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Sam")
        {
            RunText();
        }
    }

    public void RunText()
    {
        theTextBox.ReloadScript(theText);
        theTextBox.currentLine = startLine;
        theTextBox.endAtLine = endLine;
        theTextBox.EnableTextBox();
        theTextBox.playerJustInteracted = true;

        if (GetComponent<ChangerStateManager>() != null)
        {
            GetComponent<ChangerStateManager>().changeTextStateOfObj();
        }

        if (destroyWhenActivated)
        {
            Destroy(gameObject);
        }
    }
}
