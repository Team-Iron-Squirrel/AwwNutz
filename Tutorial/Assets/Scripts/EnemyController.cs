using UnityEngine;
using Prime31;
using System.Collections;

public class EnemyController : MonoBehaviour {
    public GameObject hero;
    public float chaseSpeed = 5;
    public float gravity = -35;
    public float jumpHeight = 2;
	public float enemyDelayTime = 0.6f;
	public bool isDelayed = false;
    public bool isHostile = false;
	public bool isSatisfied  = false;
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
		if (!(isDelayed) && isHostile)
		{
            if (hero.transform.position.x > transform.position.x)
            {
                velocity.x = chaseSpeed;
            }
            else
            {
                velocity.x = -chaseSpeed;
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
            _animator.setAnimation("Idle");
		}
        
        if(isHostile)
        {
            //Debug.Log("walking");
            _animator.setAnimation("Walk");
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
