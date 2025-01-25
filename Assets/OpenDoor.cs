using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

	public Animator anim;
	public GameObject target;

	// Use this for initialization
	void Start () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
		{
			other.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, other.transform.position.z);
			anim.SetBool("Open", false);
			
		}
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
