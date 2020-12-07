using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
	// Flying projectile behaviour for Pixel Art Wonderland demo scenes - not intended as final game code - included for reference only 

    public bool isFlying;
    public float direction;
    public float timer;
    public GameObject explosionPrefab;

    private void FixedUpdate()
    {
        if (isFlying)
        {
			timer += Time.deltaTime;

            transform.position += new Vector3(Time.deltaTime * 4f * direction, 0f, 0f);

            if (timer > 2.5f)
            {
                if (explosionPrefab != null)
                {
                    GameObject explosion = Instantiate<GameObject>(explosionPrefab);
                    explosion.transform.position = transform.position;
                }

                Destroy(gameObject);
            }
        }
    }

    public void Fire()
    {
        isFlying = true;
        transform.parent = null;
    }
}
