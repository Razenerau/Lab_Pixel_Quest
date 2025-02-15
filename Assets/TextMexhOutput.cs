using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextMexhOutput : MonoBehaviour
{
    public string outputText; // public variables named without "_" 
                            // public variables are also accessible from within unity editor
    private string _example2; // private variables named with "_"

    // Start is called before the first frame update
    void Start()
    {
        var textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = outputText;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
