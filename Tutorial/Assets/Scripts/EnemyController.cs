using UnityEngine;
using Prime31;
using System.Collections;

public class EnemyController : MonoBehaviour {
    public GameObject hero;
	public float Hoard;
    public float chaseSpeed = 5;
    public float gravity = -35;
    public float jumpHeight = 2;
	public float enemyDelayTime = 0.6f;
	public bool isDelayed = false;
    public bool isHostile = false;
	public bool isSatisfied  = false;
	public bool ahead = false;
    private CharacterController2D _controller;
    private AnimationController2D _animator;
	public bool playerDead = false;
	private GameObject obj;
	// Use this for initialization
	void Start () {
        _controller = gameObject.GetComponent<CharacterController2D>();
       // Debug.Log(_controller.name);
        _animator = gameObject.GetComponent<AnimationController2D>();
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 velocity = _controller.velocity;
		if (!(isDelayed) && isHostile)
		{
			
			if (hero.transform.position.x + 15 < transform.position.x) 
			{
				ahead = true;
				Debug.Log (ahead);
			}
			if (hero.transform.position.x - 15 < transform.position.x) 
			{
				ahead = false;
			}

			if (ahead)
            {
                velocity.x = -chaseSpeed;
            }
			else
            {
                velocity.x = chaseSpeed;
            }
		}
		else if (isSatisfied)
		{
			velocity.x = chaseSpeed;
		}
		else
		{
			velocity.x = 0;
            //Debug.Log("Standing");
			if (isHostile == false)
			{
				_animator.setAnimation ("Idle");
			}
			else
			{
				_animator.setAnimation ("dropping");
			}
		}
        
		if(isHostile && isDelayed == false && playerDead == false)
        {
            //Debug.Log("walking");
            _animator.setAnimation("Run");
        }
		else if (playerDead && isDelayed == false)
		{
			Debug.Log("shouldBeDancing");
			velocity.x = 0;
			obj = transform.GetChild(0).gameObject;
			var rotationVector = obj.transform.rotation.eulerAngles;
			rotationVector.y = 180;
			obj.transform.rotation = Quaternion.Euler (rotationVector);
			_animator.setAnimation ("GangnamStyle");

		}
        velocity.y += gravity * Time.deltaTime;
        _controller.move(velocity * Time.deltaTime);
    }

	void OnTriggerEnter2D(Collider2D col)
	{


		//Debug.Log(col.tag.ToString());

		if (col.tag == "aiJump")
		{
			_controller.velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);
			_animator.setAnimation ("Jump");
            
        }
		if (col.tag == "acornDrop")
		{
			isDelayed = true;
			Invoke ("ToggleDelay", enemyDelayTime);
		}
        //if(col.tag == "Avoided")
//        {
//			col.transform.parent.gameObject.GetComponent<AnimationController2D>().setFacing("Left");
//			col.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
//			Debug.Log (col.transform.parent.gameObject.GetComponent<BoxCollider2D>().tag.ToString ());
//			col.transform.parent.gameObject.GetComponent<BoxCollider2D>().tag = "Enemy";
//			//col.transform.parent.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.82f, 1.08f);
//			//col.transform.parent.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-0.1f, -0.5f);
//			col.transform.parent.gameObject.GetComponent<EnemyController>().isHostile = true;
//			Debug.Log("This is now an Enemy" + col.transform.parent.gameObject.GetComponent<BoxCollider2D>().tag.ToString ());
//			//Debug.Log ("colider size = " + col.gameObject.GetComponent<BoxCollider2D>().size.ToString());
//        }
		if (col.tag == "KillZ")
		{
			Destroy (gameObject);
		}
	}

	public void ToggleDelay()
	{
		isDelayed = false;
	}
}
