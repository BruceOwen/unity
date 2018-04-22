using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackPoints : MonoBehaviour {
    public Transform[] trackpoints;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnDrawGizmos()
    {
        iTween.DrawPath(trackpoints);
    }
}
