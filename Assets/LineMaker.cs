using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMaker : MonoBehaviour {

	public LineRenderer line;
	public Vector3 start;
	public Vector3 end;
	public float width = 0.15f;
	public BoxCollider col;

	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer> ();
		line.SetPosition(0, start);
		line.SetPosition(1, end);

		LineRenderer lineRenderer = GetComponent<LineRenderer>();
		AnimationCurve curve = new AnimationCurve();

		curve.AddKey (0.0f, 0.0f);
		curve.AddKey (0.5f, 1.0f);
		curve.AddKey (1.0f, 0.0f);

		line.widthCurve = curve;
		line.widthMultiplier = width;

		col = new GameObject("Collider").AddComponent<BoxCollider> ();
		col.transform.parent = line.transform;
	}

	// Update is called once per frame
	void Update () {
		line.SetPosition(0, start);
		line.SetPosition(1, end);
		updateCollider ();
	}

	private void updateCollider() {

		Vector3 midpoint = (end+start)/2f;
		col.transform.position = midpoint;

		float lineLength = Vector3.Distance (start, end);
		col.size = new Vector3 (lineLength, 1f, width);

		Vector3 newV = end - start;
		Quaternion rotation = Quaternion.FromToRotation (col.transform.forward, newV);
		col.transform.rotation = rotation * col.transform.rotation;
		col.transform.Rotate (0, 90, 0);

	}
}
