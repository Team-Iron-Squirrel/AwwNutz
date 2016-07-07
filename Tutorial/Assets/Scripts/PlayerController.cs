﻿using UnityEngine;
using System.Collections;
using Prime31;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float runSpeed = 3;
	public float walkSpeed = 1;
    public float gravity = -35;
    public float jumpHeight = 2;
    public float stamina = 100;
    public float staminaDownSpeed= 30;
    public float staminaUpSpeed = 50;
	public float acornAmmo;
	public float maxAmmo;
    public GameObject gameCamera;
    public GameObject gameOverPanel;
    public GameObject staminaBar;
	public GameObject aiJumper;
	public GameObject acorn;
	public GameObject ammoText;
    public GameObject scoreText;
    private CharacterController2D _controller;
    private AnimationController2D _animator;
    private float time;
    private float score;
    private float currentStamina = 0;
    private bool isDead = false;
    private bool running = true;

	// Use this for initialization
	void Start () {
        _controller = gameObject.GetComponent<CharacterController2D>();
        //Debug.Log(_controller.name);
        _animator = gameObject.GetComponent<AnimationController2D>();
        gameCamera.GetComponent<CameraFollow2D>().startCameraFollow(this.gameObject);
        currentStamina = stamina;
	}
	
	// Update is called once per frame
	void Update () {
        if (!(isDead))
        {
            Vector3 velocity = PlayerInput();
            _controller.move(velocity * Time.deltaTime);
            updateStamina();
            updateScore();
            scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
            ammoText.GetComponent<Text>().text = "Ammo: " + acornAmmo.ToString();
            float normalizedStamina = (float)currentStamina / (float)stamina;
            staminaBar.GetComponent<RectTransform>().sizeDelta = new Vector2(normalizedStamina * 256f, 32f);
        }
    }

    private void updateStamina()
    {
        if(running)
        {
            currentStamina = currentStamina - staminaDownSpeed * Time.deltaTime;
        }
        else if(currentStamina < stamina)
        {
            currentStamina = currentStamina + staminaUpSpeed * Time.deltaTime;
        }

    }
    private void updateScore()
    {
        time += Time.deltaTime;
        score = Mathf.Round(time);
    }

    private Vector3 PlayerInput()
    {
        Vector3 velocity = _controller.velocity;


        
		if (currentStamina < 1) {
			running = false;
            
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			running = false;
		}

		else if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			running = true;
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			if (acornAmmo > 0) {
				Vector3 position = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
				Instantiate (acorn, position, Quaternion.identity);
				acornAmmo--;
			}
		}



        //if(Input.GetAxis("Horizontal") < 0)
        //{
        //    velocity.x = walkSpeed * -1;
        if ((_controller.isGrounded) && (running))
        {
            _animator.setAnimation("Run");
            velocity.x = runSpeed;
        }
       // if ((!_controller.isGrounded) && (running))
       // {
       //     velocity.x = walkSpeed;
       // }
		if(!(running) && (_controller.isGrounded))
        {
            //_animator.setAnimation("Idle");
			_animator.setAnimation("Walk");
			velocity.x = walkSpeed;
        }
        // _animator.setFacing("Left");
        // }
        //else if (Input.GetAxis("Horizontal")>0)
        //{
        //    velocity.x = walkSpeed;
        //    if (_controller.isGrounded)
        //    {
        //        _animator.setAnimation("Run");
        //    }
        //    _animator.setFacing("Right");
        //}
        //else
        //{
        //    _animator.setAnimation("Idle");

        //}
		if (Input.GetAxis("Jump") > 0 && _controller.isGrounded && (running))
        {
            //Debug.Log("Jump");
            velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);
            _animator.setAnimation("Jump");
			Vector3 position = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
			Instantiate (aiJumper, position , Quaternion.identity);

        }
        //velocity.x *= .096f;

        velocity.y += gravity * Time.deltaTime;

        return velocity;
    }
    void OnTriggerEnter2D(Collider2D col)
    {


		//Debug.Log(col.tag.ToString());
		if (col.tag == "Avoided")
		{
			col.transform.parent.gameObject.GetComponent<AnimationController2D>().setFacing("Left");
			col.transform.parent.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            col.transform.parent.gameObject.GetComponent<EnemyController>().hero = this.gameObject;
			col.transform.parent.gameObject.GetComponent<BoxCollider2D>().tag = "Enemy";
			col.transform.parent.gameObject.GetComponent<EnemyController>().isHostile = true;
			
			col.transform.parent.gameObject.GetComponent<EnemyController> ().isDelayed = true;
			col.transform.parent.gameObject.GetComponent<EnemyController> ().Invoke ("ToggleDelay", 0.5F);
		}
        if (col.tag == "KillZ")
        {
            PlayerFallDeath();
        }
        if (col.tag == "Enemy")
        {
            PlayerDeath();
        }
		if (col.tag == "acorn") 
		{
			if (acornAmmo <= maxAmmo) {
				acornAmmo += 1;
				Destroy (col.gameObject);
			}
		}
		if (col.tag == "NonHostile")
		{
			if (acornAmmo >= 2) 
			{
				acornAmmo -= 2;
			}
			else if (acornAmmo == 1)
			{
				acornAmmo =0;
				currentStamina -= stamina / 20;
			} 
			else
			{
				currentStamina -= stamina / 10;
			}

			col.gameObject.GetComponent<AnimationController2D>().setFacing("Left");
			col.gameObject.GetComponent<EnemyController>().chaseSpeed = 100;
			col.gameObject.GetComponent<EnemyController>().isSatisfied  = true;
		}

    }

    private void PlayerDeath()
    {
        isDead = true;
        _animator.setAnimation("Death");
        gameOverPanel.SetActive(true);
    }

    private void PlayerFallDeath()
    {
        currentStamina = 0;
        float normalizedHealth = (float)currentStamina / (float)stamina;
        staminaBar.GetComponent<RectTransform>().sizeDelta = new Vector2(normalizedHealth*256f,32f);
        gameCamera.GetComponent<CameraFollow2D>().stopCameraFollow();
        gameOverPanel.SetActive(true);

    }
}
