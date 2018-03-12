using UnityEngine;
using System.Collections;

public class CherryRotation : MonoBehaviour {

	// Use this for initialization
	void Start() 
    {
	    
	}
	
	// Update is called once per frame
	void Update() 
    {
        this.gameObject.GetComponent<Transform>().Rotate(Vector3.up);
	}
}
