using UnityEngine;
using System.Collections;

public class SineWobble : MonoBehaviour
{
	// Hovering behaviour for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

    float wobbleHeight = 0.25f;
    Vector3 startPosition;
    float timer = 0f;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime * 2f;

        transform.position = startPosition + new Vector3(0f, Mathf.Cos(timer) * wobbleHeight, 0f);
    }
}
