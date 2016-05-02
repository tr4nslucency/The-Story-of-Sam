﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public PlayerControls player;

    public bool IsActive;

    public bool stopPlayerMovement;

    //public bool stopInteractedMovement; add later

    public bool playerJustInteracted;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerControls>();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length-1;
        }

        if (IsActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }

        playerJustInteracted = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (!IsActive)
        {
            DisableTextBox();
            return;
        }
        else
        {
            EnableTextBox();
        }

        theText.text = textLines[currentLine];

        // If the player just interacted with the object that triggered this
        // function, make the Update function run again next frame.
        // This so that the first line of text wont be skipped due to that the
        // Fire1 button is pressed.
        if (playerJustInteracted)
        {
            Debug.Log("playerJustInteracted");
            playerJustInteracted = false;
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1");
            if (currentLine >= endAtLine)
            {
                IsActive = false;
            }
            else
            {
                currentLine += 1;
            }
        }
	}

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        IsActive = true;

        if (stopPlayerMovement)
        {
            player.canMove = false;
        }
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        IsActive = false;

        player.canMove = true;
    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = (theText.text.Split('\n'));
        }
    }
}
