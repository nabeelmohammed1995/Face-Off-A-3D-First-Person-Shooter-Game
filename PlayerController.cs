using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;
    private PlayerMotor motor;
	// Use this for initialization
	void Start () {
        motor = GetComponent<PlayerMotor>();
	
	}
	
	// Update is called once per frame
	void Update () {
        //calcuate movement velocity as 3d vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 mov_Horizontal = transform.right * _xMov;
        Vector3 mov_Vertical = transform.forward * _zMov;
        //fina movement vector
        Vector3 _velocity = (mov_Horizontal + mov_Vertical).normalized * speed;

        //applying movement
        motor.Move(_velocity);
        //calculate rotation as 3d vector
        float _yRot = Input.GetAxisRaw("Mouse X");
        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;
        //apply rotation
        motor.Rotate(_rotation);
        //calculate camera rotation
        float _xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitivity;
        //apply camera rotation
        motor.Rotatecamera(_cameraRotation);
    }
}
