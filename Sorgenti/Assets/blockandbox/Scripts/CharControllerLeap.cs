using UnityEngine;
using System.Collections;
using Leap;
public class CharControllerLeap : MonoBehaviour {

	public float jumpStrength = 15f;
	public float runSpeed = 8f;
	private bool doubleJump = false;
	private Controller controller;
	private bool onFloor = true;
	private float onFloorRadius = 0.07f;
	public Transform checkOnFloor;
	public LayerMask floorLayer;

	private bool running = false;

	private Animator animator;

	// Use this for initialization
	void Start () {
		
	}

	void Awake() {
		animator = GetComponent<Animator>();
	}

	void FixedUpdate() {
		if (running) {
			rigidbody2D.velocity = new Vector2(runSpeed, rigidbody2D.velocity.y);
		}
		onFloor = Physics2D.OverlapCircle (checkOnFloor.position, onFloorRadius, floorLayer);

		animator.SetBool ("touchesGround", onFloor);
		animator.SetFloat ("speedX", rigidbody2D.velocity.x);

		if (onFloor) {
			doubleJump = false;
		}
	}

	// Update is called once per frame
	void Update () {
		this.controller = new Controller();
		Frame frame = controller.Frame(); // controller is a Controller object
		HandList hands = frame.Hands;
		Hand firstHand = hands[0];
		float strength = firstHand.GrabStrength;
		if (Input.GetMouseButtonDown (0) || ( strength>0.5)){
			if (running && (onFloor || !doubleJump)) {
				this.audio.Play();
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpStrength);
				if(!doubleJump  && !onFloor) {
					doubleJump = true;
				}
			} else if(!running) {
				running = true;
				NotificationCenter.DefaultCenter().PostNotification(this, "StartRunning");
			}
		}
	}
}
