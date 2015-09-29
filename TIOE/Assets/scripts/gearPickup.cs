//Dylan Noaker's code
using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
public class gearPickup : MonoBehaviour {
	bool pickedUp;
	Camera2DFollow followScript;
	// Use this for initialization
	void Start () {
		followScript = GetComponent<Camera2DFollow> ();
		followScript.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!pickedUp) {
			transform.Rotate(5*Vector3.right);
		}
	}
	void OnTriggerEnter(Collider col)
	{
		//on touch, start following player
		if (col.gameObject.tag == "Player"||col.gameObject.tag == "StickyAura") {
			transform.localEulerAngles=Vector3.zero;
			if(!pickedUp)
			{
				pickedUp = true;
				followScript.enabled = true;
				col.gameObject.GetComponent<GearGuyCtrl1>().gearChildren.Add(gameObject);
			}
		}
	}
	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Player"||col.gameObject.tag == "StickyAura") {

			if (pickedUp) {
				followScript.enabled = false;
			}
		}
	}
	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Player"||col.gameObject.tag == "StickyAura") {

			if (pickedUp) {
				followScript.enabled = true;
			}
		}
	}
}
