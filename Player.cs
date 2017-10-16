using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	NavMeshAgent agent;//寻路物体
	public NavMeshObstacle _navMeshObs;//障碍物
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	void OnGUI()
	{
		if (GUI.Button (new Rect (0, 0, 100, 50), "走下路")) {
			agent.walkableMask = 9;
		}
		if (GUI.Button (new Rect (0, 60, 100, 50), "走上路")) {
			agent.walkableMask = 17;
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (_navMeshObs) {
				_navMeshObs.enabled = false;
				GetComponent<MeshRenderer> ().material.color = Color.red;
			}
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				Vector3 p = hit.point;
				agent.SetDestination (p);
			}
		}
		if (Input.GetMouseButtonUp(0)) {
			if (_navMeshObs) {
				_navMeshObs.enabled = true;
				GetComponent<MeshRenderer> ().material.color = Color.blue;
			}
		}
	}
}
