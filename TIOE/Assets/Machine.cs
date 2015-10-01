using UnityEngine;
using System.Collections;

public class Machine : MonoBehaviour {
	[SerializeField] private GameObject door;
	[SerializeField] private GameObject topgear;
	[SerializeField] private GameObject frntgear;
	[SerializeField] private GameObject GearDrop;
	[SerializeField] private float rotrate;

	[SerializeField] private MeshRenderer gearDropMat;
	[SerializeField] private bool activated;
	[SerializeField] private float deviceDuration;
	private float tempDevDur;
	// Use this for initialization
	void Start () {
		gearDropMat = GearDrop.GetComponent<MeshRenderer> ();
		tempDevDur = deviceDuration;
	}
	
	// Update is called once per frame
	void Update () {
		if(activated)
		{
			topgear.transform.Rotate(rotrate*Vector3.forward);
			frntgear.transform.Rotate(rotrate*Vector3.forward);
			GearDrop.transform.Rotate(rotrate*Vector3.forward);
			tempDevDur-=Time.deltaTime;
			if(tempDevDur>0)
				door.transform.position = door.transform.position - (rotrate*Time.deltaTime*Vector3.up);
		}
	
	}
}
