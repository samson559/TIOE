using UnityEngine;
using System.Collections;

public class Machine : MonoBehaviour {
	[SerializeField] private GameObject door;
	[SerializeField] private GameObject topgear;
	[SerializeField] private GameObject frntgear;
	[SerializeField] private GameObject GearDrop;
	[SerializeField] private float rotrate;
	[SerializeField] private float distToMove;
	[SerializeField] private MeshRenderer gearDropMat;
	[SerializeField] private bool activated;
	[SerializeField] private float deviceDuration;
	private float tempDevDur;
	// Use this for initialization
	void Start () {
		gearDropMat = GearDrop.GetComponent<MeshRenderer> ();
		tempDevDur = deviceDuration;
		distToMove = gameObject.GetComponent<Collider> ().bounds.extents.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(activated&&tempDevDur>0)
		{
			topgear.transform.Rotate(rotrate*Vector3.back);
			frntgear.transform.Rotate(rotrate*Vector3.back);
			GearDrop.transform.Rotate(rotrate*Vector3.back);
			tempDevDur-=Time.deltaTime*rotrate;
			if(tempDevDur>0)
				door.transform.position = door.transform.position - (rotrate*Time.deltaTime*Vector3.up);
			Debug.Log(tempDevDur);
		}
	
	}
	void OnCollisonEnter(Collision col)
	{
	}
}
