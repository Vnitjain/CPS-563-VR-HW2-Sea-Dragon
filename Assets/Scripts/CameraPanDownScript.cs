using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanDownScript : MonoBehaviour
{
    [SerializeField] public GameObject targetObject; // The object to pan down to
    [SerializeField] public float duration = 1f; // Duration of the pan

    private void Start()
    {
        StartCoroutine(PanToTarget());
    }

    IEnumerator PanToTarget()
    {
        Vector3 startPosition = transform.position; // Starting position
        Vector3 endPosition = targetObject.transform.position; // Target position

        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration; // Normalized time
            t = t * t * (3f - 2f * t); // Apply easing (fast to slow)

            transform.position = Vector3.Lerp(startPosition, endPosition, t); // Interpolate position

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition; // Ensure the final position is accurate
    }
}
