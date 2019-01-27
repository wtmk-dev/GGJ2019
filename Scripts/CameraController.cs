using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

	public bool allowMoveOnX = false;
//holds the value of player game object
	[SerializeField]
	private Transform player;
	[SerializeField]
	private Vector3 offset = new Vector3();
	[SerializeField]
	private float cameraSpeed = 0f;

	// Update is called once per frame
	void FixedUpdate () {
		//if( player != null ){
			Vector3 currentPos = player.transform.position + offset;
			
			if( allowMoveOnX ){
				Vector3 toPosWithY = new Vector3( currentPos.x, currentPos.y, offset.z );
				transform.position = Vector3.Lerp(transform.position, toPosWithY, Time.fixedDeltaTime * cameraSpeed);
			}
			else{
				Vector3 toPos = new Vector3( offset.x, currentPos.y, offset.z );
				transform.position = Vector3.Lerp(transform.position, toPos, Time.fixedDeltaTime * cameraSpeed);
			}

		//} 
		
	}


}
