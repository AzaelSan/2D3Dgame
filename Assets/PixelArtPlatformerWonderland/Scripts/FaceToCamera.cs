using UnityEngine;
using System.Collections;

public class FaceToCamera : MonoBehaviour
{
	// Forward-facing 2D object Pixel Art Wonderland 3D demo scene - not intended as final game code - included for reference only 

	void LateUpdate ()
    {
        Vector3 displacement = Camera.main.transform.position - transform.position;

        transform.localEulerAngles = new Vector3(0f, 270f - (Mathf.Atan2(displacement.z, displacement.x) * Mathf.Rad2Deg), 0f);
	}
}
