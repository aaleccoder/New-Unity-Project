using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MinigameCard : MonoBehaviour
{

	public Sprite[] cards;
	public GameObject[] cardsGameObject;
	public GameObject cardPrefab;

	public bool state;
	public bool error;
	public int count;
	public bool canFlip = true;


	// Use this for initialization
	void Start()
	{

	}


	public void ShowMinigame()
	{
		if (state) return;
		gameObject.SetActive(true);
		GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().canMove = false;
		state = true;
		lol();
	}

	public void lol()
	{
		int[] originalArray = new int[cards.Length];
		for (int i = 0; i < cards.Length; i++)
		{
			originalArray[i] = i;
		}


		// Step 1: Manually duplicate each element twice
		int[] duplicatedArray = new int[originalArray.Length * 2];
		for (int i = 0; i < originalArray.Length; i++)
		{
			duplicatedArray[2 * i] = originalArray[i];
			duplicatedArray[2 * i + 1] = originalArray[i];
		}

		// Step 2: Fisher-Yates shuffle (with explicit temp variable)
		System.Random rng = new System.Random();
		for (int i = duplicatedArray.Length - 1; i > 0; i--)
		{
			int j = rng.Next(i + 1);

			// Swap using temporary variable
			int temp = duplicatedArray[i];
			duplicatedArray[i] = duplicatedArray[j];
			duplicatedArray[j] = temp;
		}

		cardsGameObject = new GameObject[duplicatedArray.Length];
		for (int i = 0; i < duplicatedArray.Length; i++)
		{
			cardsGameObject[i] = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity, transform.GetChild(0));
			cardsGameObject[i].GetComponent<Card>().sprite = cards[duplicatedArray[i]];
			cardsGameObject[i].GetComponent<Card>().number = duplicatedArray[i];
		}
	}

	IEnumerator WaitToFlipCards()
	{
		yield return new WaitForSeconds(2);
		canFlip = true;
		for (int i = 0; i < cardsGameObject.Length; i++)
		{
			if (cardsGameObject[i].GetComponent<Animator>().GetBool("flipIt"))
			{
				cardsGameObject[i].GetComponent<Card>().anim.SetBool("flipIt", false);
				StartCoroutine(cardsGameObject[i].GetComponent<Card>().WaitToFlipCards());
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		int number1 = -1;
		int number2 = -1;
		for (int i = 0; i < cardsGameObject.Length; i++)
		{
			if (cardsGameObject[i].GetComponent<Card>().anim.GetBool("flipIt"))
			{
				if (number1 == -1)
				{
					number1 = cardsGameObject[i].GetComponent<Card>().number;
				}
				else
				{
					number2 = cardsGameObject[i].GetComponent<Card>().number;
				}
			}

		}
		if (number1 != -1 && number2 != -1)

		{
			canFlip = false;
			Debug.Log(number1);
			Debug.Log(number2);
			
			if (number1 == number2)
			{
				
					
			}
			else
			{
				error = true;
			}

		}
		if (error)
		{
			error = false;
			StartCoroutine(WaitToFlipCards());
		}

	}
}
