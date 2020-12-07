using UnityEngine;
using System.Collections;

public class GoblinArcher : MonoBehaviour
{
	// Patrolling / shooting enemy behaviour for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

    float timer = 0f;
    float direction = 1f;

    public Arrow arrowPrefab;
    public Vector3 arrowStartPosition;

    Arrow myArrow;

	bool hasFired;
    bool hasReloaded;

    private void Awake()
    {
        SpawnArrow();
    }

    void SpawnArrow()
    {
        myArrow = Instantiate<Arrow>(arrowPrefab);
        myArrow.transform.parent = transform;
        myArrow.transform.localPosition = arrowStartPosition;
        myArrow.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer < 1f)
        {
            GetComponent<Animator>().SetBool("IsWalking", true);

            transform.position += new Vector3(Time.deltaTime * 2f * direction, 0f, 0f);
        }
        else if (timer < 4f)
        {
            GetComponent<Animator>().SetBool("IsWalking", false);
        }
        else if (timer < 5f)
        {
            if (!hasFired)
            {
                myArrow.direction = direction;
                myArrow.Fire();

                GetComponent<Animator>().SetTrigger("Fire");

                hasFired = true;
				hasReloaded = false;
            }
        }
        else if (timer < 5.1f)
        {
			if (!hasReloaded) {
				hasReloaded = true;
				SpawnArrow ();
			}

            GetComponent<Animator>().SetBool("IsWalking", false);
        }
        else
        {
            hasFired = false;

            direction = -direction;
            timer = 0f;

            transform.localScale = new Vector3(direction, 1f, 1f);
        }
    }
}
