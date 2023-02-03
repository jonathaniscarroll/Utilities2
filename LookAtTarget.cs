using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
	public Vector3 Mod = Vector3.one;
	public Transform Target{
		get;set;
	}
	[TagSelector]
	public string TargetTag;
	
	void Start(){
		if(!string.IsNullOrEmpty(TargetTag)){
			Target = GameObject.FindGameObjectWithTag(TargetTag).transform;
		}
	}
	
	void Update(){
		//transform.LookAt(Target.position);
		if(Target!=null){
			//Debug.Log(Target.name);
			Vector3 dir = transform.position - Target.position;
			dir.x*=Mod.x;
			dir.y*=Mod.y;
			dir.z*=Mod.z;
			//dir.x = 0; // keep the direction strictly horizontal
			//dir.z = 0;
			//dir.y = 0;
			Quaternion rot = Quaternion.LookRotation(dir);
			// slerp to the desired rotation over time
			transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
		}
		
	}
}
