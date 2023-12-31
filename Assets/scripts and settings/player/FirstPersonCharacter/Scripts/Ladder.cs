// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
public class Ladder: MonoBehaviour {

	
	void OnTriggerEnter () {
		    GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().enabled = false;
			GameObject.FindGameObjectWithTag("Player").GetComponent<LadderController>().enabled = true;

	}
	
	void OnTriggerExit () {
	 	GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().enabled = true;
		GameObject.FindGameObjectWithTag("Player").GetComponent<LadderController>().enabled = false;
	}
}
