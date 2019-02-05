using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed; //how fast it moves
	public Text counterText;
	public Text winner;
	
	private int count;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody>();
		count = 0;
		counterText.text = " Pill-Count: " + count.ToString(); 
		winner.text = "";

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement);
	}

	void OnTriggerEnter (Collider other){
		if(other.gameObject.CompareTag("Pick Up")){
			other.gameObject.SetActive (false);
			count = count + 1;
			counterText.text = " Pill-Count: " + count.ToString();
			if(count >= 10){
				winner.text = "You've Won!!!";
			}
		}
	}
}
