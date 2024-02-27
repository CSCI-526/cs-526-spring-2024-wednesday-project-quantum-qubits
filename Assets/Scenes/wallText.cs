using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class wallText : MonoBehaviour
{
    public SpriteRenderer circleSpriteRenderer;     
    public TextMeshProUGUI textToDisable; // Assign your TextMeshProUGUI component here

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the circle's color is approximately red
        if (circleSpriteRenderer.color.r > 0.9 && circleSpriteRenderer.color.g < 0.1 && circleSpriteRenderer.color.b < 0.1)
        {
            // Disable the TextMeshProUGUI component
            textToDisable.enabled = false;
        }
        
    }
}
