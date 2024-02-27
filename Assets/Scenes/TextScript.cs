using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Include the TextMeshPro namespace


public class TextScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textMeshProToDisappear;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for any of the arrow keys being pressed
        if (Input.GetKeyDown(KeyCode.UpArrow) || 
            Input.GetKeyDown(KeyCode.DownArrow) || 
            Input.GetKeyDown(KeyCode.LeftArrow) || 
            Input.GetKeyDown(KeyCode.RightArrow))
        {
            // If any arrow key is pressed, disable the TextMeshPro component
            textMeshProToDisappear.enabled = false;
        }
        
    }
}
