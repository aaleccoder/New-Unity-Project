using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

	public Sprite sprite;
	public int number;
	public Animator anim;
	public Sprite generic;




	// Use this for initialization
	void Start () {
		
	}

	public IEnumerator WaitToFlipCards(){
		yield return new WaitForSeconds(0.165f);
		if (!anim.GetBool("flipIt")) {
			gameObject.GetComponent<Image>().sprite = generic;
		} else {
			gameObject.GetComponent<Image>().sprite = sprite;
		}
	}

	public void flip() {

		if (!transform.parent.parent.GetComponent<MinigameCard>().canFlip) return;
		anim.SetBool("flipIt", true);
		StartCoroutine(WaitToFlipCards());
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}
