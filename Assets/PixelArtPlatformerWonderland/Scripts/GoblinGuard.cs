using UnityEngine;
using System.Collections;

public class GoblinGuard : MonoBehaviour
{
	// Patrolling enemy behaviour for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

    float timer = 0f;
    float direction = 1f;

    bool hasFired;

    public bool mirrorOnTurn = true;

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer < 1f)
        {
            GetComponent<Animator>().SetBool("IsWalking", true);

            transform.position += new Vector3(Time.deltaTime * 2f * direction, 0f, 0f);
        }
        else if (timer < 3.6f)
        {
            GetComponent<Animator>().SetBool("IsWalking", false);
        }
        else if (timer < 5f)
        {
            if (!hasFired)
            {
                GetComponent<Animator>().SetTrigger("Fire");

                hasFired = true;
            }
        }
        else if (timer < 5.1f)
        {
            GetComponent<Animator>().SetBool("IsWalking", false);
        }
        else
        {
            hasFired = false;

            direction = -direction;
            timer = 0f;

            if (mirrorOnTurn)
            {
                transform.localScale = new Vector3(direction, 1f, 1f);
            }
           
        }
    }

}
