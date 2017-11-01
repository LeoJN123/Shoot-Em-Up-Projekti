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


	public void EnableOrDisablsStartMenuButtons()
	{
		foreach (GameObject button in StartMenuButtons) {
			button.SetActive(!button.activeSelf);
			if (button.activeSelf) {
				foreach (ButtonScript Bs in Bss) {

					Bs.currentY = 0f;

				}


			}
		}
	}

	public void EnableOrDisablsOptionsMenuButtons()
	{
		foreach (GameObject button in OptionsMenuButtons) {
            button.SetActive(!button.activeSelf);
			if (button.activeSelf) {
				foreach (ButtonScript Bs in Bss) {
				
					Bs.currentY = 430f;
				
				}


			}
		}
	}



}
