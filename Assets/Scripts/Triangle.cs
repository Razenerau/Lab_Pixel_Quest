using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    [SerializeField] private const int _speed = 7;
    [SerializeField] private const float _JUMPSTRENGTH = 0.05f;
    public Rigidbody2D rb;

    private float xInput;
    private float yInput;

    private float _jumpCooldown = 1f;
    private float _currentJumpCooldown = 1f;
    private bool _canJump = true;

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
        Debug.Log(xInput);
        rb.velocity = new Vector2(xInput * _speed, rb.velocity.y + (yInput) * _JUMPSTRENGTH);
    }
}
