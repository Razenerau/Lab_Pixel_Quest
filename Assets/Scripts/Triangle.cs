using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Triangle : MonoBehaviour
{
    [SerializeField] private const int _speed = 7;
    [SerializeField] private const float _JUMPSTRENGTH = 0.04f;
    public Rigidbody2D rb;

    private float xInput;
    private float yInput;

    private float _jumpCooldown = 1f;
    private float _currentJumpCooldown = 1f;
    private bool _canJump = true;
    private bool _isJumping = false;

    // Tags
    private const string _GROUNDTAG = "Ground";
    private const string _ENEMYTAG = "Enemy";
    private const string _FINISHTAG = "Finish";

    //Levels
    private const string _NEXT_LEVEL = "Level 2";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void handleMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            move('W');
        }
        if (Input.GetKey(KeyCode.A))
        {
            move('A');
        }
        if (Input.GetKey(KeyCode.D))
        {
            move('D');
        }
    }

    private void move(char key)
    {
        switch (key)
        {
            case 'W':
                
                break;
            case 'S':
                break;
            case 'A':
                rb.velocity = new Vector2(_speed * -1, rb.velocity.y);
                break;
            case 'D':
                rb.velocity = new Vector2(_speed, rb.velocity.y);
                break;
            default:
                rb.velocity = Vector2.zero;
                break;
        }
    }

    private void move()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        //Debug.Log(yInput);
        rb.velocity = new Vector2(xInput * _speed, rb.velocity.y);
        jump();
        if(_isJumping) handleJumpCooldown();
        if(Input.GetKeyDown(KeyCode.W) && _canJump)
        {
            _currentJumpCooldown = _jumpCooldown;
        }
        if(!Input.GetKey(KeyCode.W))
        {
            _isJumping = false;
        }

    }

    private void handleJumpCooldown()
    {
        Debug.Log("Countdown Jump: " + _currentJumpCooldown);
        if (_currentJumpCooldown <= 0)
        {
            Debug.Log("Disable Jump");
            _canJump = false;
        }
        else
        {
            //Debug.Log("Countdown Jump: " + _currentJumpCooldown);
            _currentJumpCooldown -= Time.deltaTime;
        }
    }

    private void jump()
    {
        if(_canJump && yInput > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + (yInput) * _JUMPSTRENGTH);
            _isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case _GROUNDTAG:
                Debug.Log("Player collides with " + collision.gameObject.tag);
                _isJumping = false;
                _canJump = true;
                break;
            case _ENEMYTAG:
                string thisLevel = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(thisLevel);
                break;
            case _FINISHTAG:
                SceneManager.LoadScene(_NEXT_LEVEL);
                break;
        }
    }
}
