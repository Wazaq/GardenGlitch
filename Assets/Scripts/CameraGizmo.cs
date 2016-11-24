using UnityEngine;
using System.Collections;

public class CameraGizmo : MonoBehaviour {

	void OnDrawGizmos() {
		Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
	}
}
