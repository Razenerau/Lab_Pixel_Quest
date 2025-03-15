using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTwo : MonoBehaviour
{
    [SerializeField] private int _speed = 7;
    public Rigidbody2D rb;

    private float xInput;

    //Levels
    private const string _NEXT_LEVEL = "Level 2";

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * _speed * -1, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case Structs.Tags.ENEMYTAG:
                string thisLevel = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(thisLevel);
                break;
            case Structs.Tags.FINISHTAG:
                Structs.LevelManager.isBlackPlayerFinish = true;
                if (Structs.LevelManager.isWhitePlayerFinish == true) SceneManager.LoadScene(_NEXT_LEVEL);
                break;
        }
    }
}
