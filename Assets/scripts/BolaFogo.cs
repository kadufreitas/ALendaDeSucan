using UnityEngine;
using System.Collections;

public class BolaFogo : MonoBehaviour {
	private float posicaoY = 0f;
	
	// Use this for initialization
	void Start () {
		Destroy (gameObject,2f);
		rigidbody2D.AddForce (transform.up * 400f);
		posicaoY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (posicaoY > transform.position.y) { //Descendo
			transform.eulerAngles = new Vector2(180, 0);
		}
		posicaoY = transform.position.y;
	}
	
	void OnCollisionEnter2D(Collision2D colisor) {
		if (colisor.gameObject.tag == "Player") {
			var player = colisor.gameObject.GetComponent<Player>();
			player.PerdeVida(10);
		}
		Destroy (gameObject);
	}

}
