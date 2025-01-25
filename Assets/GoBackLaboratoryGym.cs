using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackLaboratoryGym : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
	void Start () {
		
	}

	private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
		{
			other.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, other.transform.position.z);
		}
    
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
