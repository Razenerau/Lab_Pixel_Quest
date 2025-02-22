using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public int frameNumber = 0;
    public TextMeshPro textMesh;
    private Vector3 position = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(position);

        if(textMesh == null )
        {
            Debug.Log("textMesh not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //frameNumber++;
        //textMesh.text = "" + frameNumber;
    }
}
