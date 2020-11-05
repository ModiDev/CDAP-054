using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlatformerInput : MonoBehaviour {

	Vector2 speed;
	public float walkSpeed = 4;
	public float jumpSpeed = 1;
	public float gravity = -2;


	float ground;

	SpriteRenderer sr;

	float walkTime = 0.1f;

	public Sprite jump, stand, walk1, walk2;
	bool currntPlatformAndroid = false;
	Rigidbody2D rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D> ();
		#if UNITY_ANDROID
		currntPlatformAndroid = true;
		#else
		currntPlatformAndroid=false;
		#endif
	}

	// Use this for initialization
	void Start () {
		ground = transform.position.y;
		sr = GetComponent<SpriteRenderer>();
		if (currntPlatformAndroid == true){
			Debug.Log ("Android");
		}else{
			Debug.Log("Windows");
		}
	}

	
	// Update is called once per frame
	void Update () {
		if (currntPlatformAndroid == true) {
			//android specific code
		} else 
			
			if (Input.GetKey (KeyCode.RightArrow)) {
				speed.x = walkSpeed;
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				speed.x = -walkSpeed;
			} else {
				speed.x = 0;
			}

			if (ground == transform.position.y && Input.GetKey (KeyCode.Space)) {
				speed.y = jumpSpeed;
			}

			if (ground != transform.position.y) {
				speed.y = speed.y + gravity * Time.deltaTime;
			}

			if (ground > transform.position.y) {
				speed.y = 0;
				Vector3 position = transform.position;
				position.y = ground;
				transform.position = position;
			}



			transform.Translate (Time.deltaTime * speed.x, Time.deltaTime * speed.y, 0);

			if (speed.y != 0) {sr.sprite = jump;} else {
				if (speed.x != 0) {walkTime = walkTime - Time.deltaTime;
					if (walkTime <= 0) {
						if (sr.sprite == walk1) {
							sr.sprite = walk2;


						} else {
							sr.sprite = walk1;

					}
						

						walkTime = 0.1f;
					}
				} else {
					sr.sprite = stand;
				}
			}

			if (speed.x > 0) {
				sr.flipX = false;
			} else if (speed.x < 0) {
				sr.flipX = true;
			}

		}

	public void Right()
	{
		speed.x = walkSpeed;
	}
	public void Left()
	{
		speed.x = -walkSpeed;
	}
	public void Zero()
	{
		speed.x = 0;
	}
	public void Jump()
	{
		speed.y = jumpSpeed;
		Vector3 position = transform.position;
		position.y = ground;
		transform.position = position;

	}
	public void NoJump()
	{
		speed.y = speed.y + gravity * Time.deltaTime;
	
	}


}
