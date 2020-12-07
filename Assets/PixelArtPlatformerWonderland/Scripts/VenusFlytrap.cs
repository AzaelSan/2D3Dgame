using UnityEngine;
using System.Collections;

public class VenusFlytrap : MonoBehaviour
{
	// Biting enemy behaviour for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

    float timer;

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer > 5f)
        {
            GetComponent<Animator>().SetTrigger("Fire");

            timer = 0f;
        }
    }
}
