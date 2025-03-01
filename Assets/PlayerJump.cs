using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody2D rb;

    private bool _canJump = true;
    private bool _isGroundCollision = false;

    private float yInput;

    [SerializeField]
    private int _jumpStrength = 0;
    private float _jumpTimer = 0;
    private int _fallStrength = -50;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _canJump)
        {
            _jumpTimer = 1;
            rb.velocity = new Vector2(rb.velocity.x, _jumpStrength);
            _canJump = false;   
        }
        
        if(!Input.GetKey(KeyCode.Space) && _jumpTimer > 0)// && rb.velocity.y > -50)
        {
            _jumpTimer += Time.deltaTime;
            rb.velocity = new Vector2(rb.velocity.x, _fallStrength * (_jumpTimer - 0.9f));
            Debug.Log(_jumpTimer);
        } 
    }

    private void jump()
    {
        // if space is pressed,
        // if the player is on the ground
        // if the space is pressed for no longer than 1 sec

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                //rb.velocity = new Vector2(rb.vecol);
                _jumpTimer = 0;
                _canJump = true;
                break;
        }
    }
}
