using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransformMoveToward : MonoBehaviour
{
	public Transform TargetToMove{
		get{return _targetToMove;}
		set{_targetToMove = value;}
	}
	[SerializeField]
	private Transform _targetToMove;
	
	public Transform TargetToMoveToward{
		get{return _targetToMoveToward;}
		set{_targetToMoveToward = value;}
	}
	[SerializeField]
	private Transform _targetToMoveToward;
	public float Speed{
		get{
			return speed;
		}
		set{
			speed = value;
		}
	}
	[SerializeField]
	private float speed = 1;
	public UnityEvent OnDestination;
	
	public void MoveToward(){
		if(TargetToMove==null||TargetToMoveToward==null){
			return;
		}
		TargetToMove.position = Vector3.MoveTowards(TargetToMove.position,TargetToMoveToward.position,Speed*Time.deltaTime);
		if(Vector3.Distance(TargetToMove.position,TargetToMoveToward.position)<0.1){
			OnDestination.Invoke();
		}
	}
}
