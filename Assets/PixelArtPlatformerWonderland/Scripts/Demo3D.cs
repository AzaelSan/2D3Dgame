using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Demo3D : MonoBehaviour
{
	// 3D character controller for Pixel Art Wonderland 3D demo scene - not intended as final game code - included for reference only 

    float sensitivityX = 2f;
    float sensitivityY = 2f;
    public float minimumX = -360f;
    public float maximumX = 360f;
    public float minimumY = -60f;
    public float maximumY = 60f;

    float rotationX = 0f;
    float rotationY = 0f;
    Quaternion originalRotation;

    void Update()
    {
        Camera cam = Camera.main;

        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationX = ClampAngle(rotationX, minimumX, maximumX);
        rotationY = ClampAngle(rotationY, minimumY, maximumY);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
        transform.localRotation = originalRotation * xQuaternion * yQuaternion;

        Vector3 realRotation = transform.localEulerAngles;

        Vector3 angles = transform.localEulerAngles;
        angles.x = 0f;
        transform.localEulerAngles = angles;
       
        cam.transform.Translate(Vector3.forward * 2f * Time.deltaTime * Input.GetAxis("Vertical"));

        cam.transform.Translate(Vector3.right * 2f * Time.deltaTime * Input.GetAxis("Horizontal"));

        transform.localEulerAngles = realRotation;

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene("DemoMenu");
		}
    }
		
    void Start()
    {
        originalRotation = transform.localRotation;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
        {
            angle += 360F;
        }
         
        if (angle > 360F)
        {
            angle -= 360F;
            
        }

        return Mathf.Clamp(angle, min, max);
    }
}
