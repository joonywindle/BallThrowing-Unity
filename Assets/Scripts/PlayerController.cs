using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	private int count;
	public Text countText;
	public Text winText;
	// Use this for initialization
	void Start () {
		this.rb = GetComponent<Rigidbody> ();
		this.count = 0;
		UpdateScore();
		winText.text = "";
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			count++;
			UpdateScore();

		}
		
	}

	void UpdateScore(){
		countText.text = "Score: " + this.count.ToString ();
		if (count >= 8)
			winText.text = "YOU WIN!";
	}

}
