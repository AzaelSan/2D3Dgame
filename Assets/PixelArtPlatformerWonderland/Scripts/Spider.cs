using UnityEngine;
using System.Collections;

public class Spider : MonoBehaviour
{
	// Dropping enemy behaviour for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

    bool isDropping = true;
    float timer;

	void FixedUpdate ()
    {
        timer += Time.deltaTime;

        if (isDropping)
        {
            transform.position += new Vector3(0f, -2f * Time.deltaTime, 0f);

            GetComponent<Animator>().SetBool("IsDropping", true);

            if (timer > 1f)
            {
                timer -= 1f;
                isDropping = false;
            }
        }
        else
        {
            transform.position += new Vector3(0f, 1f * Time.deltaTime, 0f);

            GetComponent<Animator>().SetBool("IsDropping", false);

            if (timer > 2f)
            {
                timer -= 2f;
                isDropping = true;
            }
        }
	}
}
