using UnityEngine;
using System.Collections;

public class Skeleton : MonoBehaviour {
	public float velocidade;
	public bool direcao;
	public float duracaoDirecao;
	
	private float tempoNaDirecao;
	private Animator animator; 
	
	// Use this for initialization
	void Start () {
		animator = gameObject.transform.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (direcao) {
			transform.eulerAngles = new Vector2(0, 0);
		} else {
			transform.eulerAngles = new Vector2(0, 180);
		}
		transform.Translate(Vector2.right * velocidade * Time.deltaTime);
		
		tempoNaDirecao += Time.deltaTime;
		if (tempoNaDirecao >= duracaoDirecao) {
			tempoNaDirecao = 0;
			direcao = !direcao;
		}
	}
	
	void OnCollisionEnter2D(Collision2D colisor) {
		if (colisor.gameObject.tag == "Player") {
			
			animator.SetTrigger("atacou");
			
			var player = colisor.gameObject.transform.GetComponent<Player>();
			player.PerdeVida(30);
			var forca = 0.2f;
			colisor.gameObject.transform.Translate(-Vector2.right * forca);
			//colisor.gameObject.rigidbody2D.(-Vector2.up * forca);
				
		}
	}
}
