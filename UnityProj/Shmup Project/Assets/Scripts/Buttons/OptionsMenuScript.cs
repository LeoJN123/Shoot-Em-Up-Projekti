using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuScript : MonoBehaviour {
	public GameObject[] StartMenuButtons;
	public GameObject[] OptionsMenuButtons;
	public ButtonScript[] Bss;



	// Use this for initialization
	void Start () {





		Bss = FindObjectsOfType<ButtonScript> ();
	}

	// Update is called once per frame
	void Update () {
		
	}


	public void EnableOrDisablsStartMenuButtons()
	{
		foreach (GameObject button in StartMenuButtons) {
			button.active = !button.active;
			if (button.active) {
				foreach (ButtonScript Bs in Bss) {

					Bs.currentY = 0f;

				}


			}
		}
	}

	public void EnableOrDisablsOptionsMenuButtons()
	{
		foreach (GameObject button in OptionsMenuButtons) {
			button.active = !button.active;
			if (button.active) {
				foreach (ButtonScript Bs in Bss) {
				
					Bs.currentY = 430f;
				
				}


			}
		}
	}



}
