using UnityEngine;
using System.Collections;

public class Hover : MonoBehaviour
{
	// Hovering behaviour for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

    Vector3 startPosition;
    float timer = 0f;

    public float frequency = 2f;
    public float amplitude = 0.5f;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime * frequency;

        transform.position = startPosition + new Vector3(0f, Mathf.Cos(timer) * amplitude, 0f); 
    }
}
