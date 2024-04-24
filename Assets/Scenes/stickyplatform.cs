using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SticyPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SetParentWithDelay(collision.transform, transform));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SetParentWithDelay(collision.transform, null));
        }
    }

    IEnumerator SetParentWithDelay(Transform child, Transform newParent)
    {
        yield return new WaitForEndOfFrame(); // Waits for the current frame to end
        child.SetParent(newParent);

        if (newParent != null)
        {
            // Calculate the new local scale to maintain the original world scale
            Vector3 worldScale = new Vector3(0.2f, 0.2f, 1); // Original desired world scale
            Vector3 parentWorldScale = newParent.lossyScale; // Current scale of the platform
            Vector3 newLocalScale = new Vector3(
                worldScale.x / parentWorldScale.x,
                worldScale.y / parentWorldScale.y,
                worldScale.z / parentWorldScale.z
            );
            child.localScale = newLocalScale;
        }
        else
        {
            // Reset local scale to default if there is no parent
            child.localScale = new Vector3(0.2f, 0.2f, 1);
        }
    }


}

