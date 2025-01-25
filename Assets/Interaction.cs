using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Interaction : MonoBehaviour {

	public UnityEvent miEvento;
	public GameObject dialog;
	public string message;

	// Use this for initialization
	void Start () {
		
	}

	public void InvocarEvento() {
		if (miEvento != null) {
			miEvento.Invoke();
			Debug.Log("Evento Invocado");
		}
	}

	public void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			dialog.SetActive(true);
			dialog.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = message;
		}

	}

	void OnTriggerStay(Collider other) {
		if (other.CompareTag("Player")) {
			if( Input.GetKeyDown("z") ) {
				InvocarEvento();
			}
		}
	}

	public void OnTriggerExit(Collider other) {
		if (other.CompareTag("Player")) {
			dialog.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
