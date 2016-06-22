using UnityEngine;
using Prime31;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float chaseSpeed = 5;
    public float gravity = -35;
    public float jumpHeight = 2;
	public float enemyDelayTime = 0.6f;
	private bool isDelayed = false;
    public bool isHostile = false;
    private CharacterController2D _controller;
    private AnimationController2D _animator;
	// Use this for initialization
	void Start () {
        _controller = gameObject.GetComponent<CharacterController2D>();
       // Debug.Log(_controller.name);
        _animator = gameObject.GetComponent<AnimationController2D>();
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 velocity = _controller.velocity;
		if (!(isDelayed) && isHostile) {
			velocity.x = chaseSpeed;
		}
		else
		{
			velocity.x = 0;
            Debug.Log("Standing");
            _animator.setAnimation("Idle");
		}
        
        if(_controller.isGrounded & isHostile)
        {
            Debug.Log("walking");
            _animator.setAnimation("Walk");
        }

        velocity.y += gravity * Time.deltaTime;
        _controller.move(velocity * Time.deltaTime);
    }

	void OnTriggerEnter2D(Collider2D col)
	{


		Debug.Log(col.tag.ToString());

		if (col.tag == "aiJump")
		{
			_controller.velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);
            
        }
		if (col.tag == "acornDrop")
		{
			isDelayed = true;
			Invoke ("ToggleDelay", enemyDelayTime);
		}
        if(col.tag == "NonHostile")
        {
            col.gameObject.GetComponent<AnimationController2D>().setFacing("Left");
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            col.tag = "Enemy";
            col.gameObject.GetComponent<EnemyController>().isHostile = true;
            Debug.Log("This is now an Enemy" + col.tag.ToString());
        }
	}

	void ToggleDelay()
	{
		isDelayed = false;
	}
}
