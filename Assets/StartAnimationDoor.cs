using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationDoor : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
		
	}

	private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
		{
			anim.SetBool("Open", true);
		}
    
    }
	// Update is called once per frame
	void Update () {
		
	}
}
