using UnityEngine;
using System.Collections;

public class Witch : MonoBehaviour
{
	// Hovering / patrolling behaviour for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

    float hoverTimer = 0f;
    float timer = 0f;
    float direction = 1f;
    Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        hoverTimer += Time.deltaTime * 2f;

        Vector3 position = transform.position;
        position.y = startPosition.y + Mathf.Cos(hoverTimer) * 0.5f;
        transform.position = position;

        if (timer < 3f)
        {
            GetComponent<Animator>().SetBool("IsWalking", true);

            transform.position += new Vector3(Time.deltaTime * 2f * direction, 0f, 0f);
        }
        else
        {
            direction = -direction;
            timer = 0f;

            transform.localScale = new Vector3(direction, 1f, 1f);
        }
    }
}
