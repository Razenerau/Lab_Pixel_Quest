using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int _speed = 7;
    public Rigidbody2D rb;

    private float xInput;
    private float yInput;

    // Tags
    private const string _GROUNDTAG = "Ground";
    private const string _ENEMYTAG = "Enemy";
    private const string _FINISHTAG = "Finish";

    //Levels
    private const string _NEXT_LEVEL = "Level 2";

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void handleMovement()
    {
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
        rb.velocity = new Vector2(xInput * _speed, rb.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
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
