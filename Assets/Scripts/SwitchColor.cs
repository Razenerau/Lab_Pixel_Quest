using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SwitchColor : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject gameObject;

    private Color c1;
    private Color c2;
    private Color c3;

    private void Start()
    {
        switch (gameObject.tag)
        {
            case Structs.Tags.PLAYERONE:
                c1 = Color.white;
                c2 = Color.blue;
                c3 = Color.green;
                break;
            case Structs.Tags.PLAYERTWO:
                c1 = Color.black;
                c2 = new Color(255f, 165f, 0f);
                c3 = Color.red;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            spriteRenderer.color = c1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spriteRenderer.color = c2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spriteRenderer.color = c3;
        }
    }
}
