using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class CharacterLook : MonoBehaviour
{
    [SerializeField] private float lookSensitivity = 5.0f;
    [SerializeField] private float minAngle = -80.0f;
    [SerializeField] private float maxAngle = 75.0f;

    private Camera playerCamera;
    private float mouseY;
    private float mouseX;
    private float currentXRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        // left/right camera control
        transform.Rotate(Vector3.up * mouseX);

        // up/down camera control
        currentXRotation -= mouseY;
        currentXRotation = Mathf.Clamp(currentXRotation, minAngle, maxAngle);
        playerCamera.transform.localEulerAngles = new Vector3(currentXRotation, 0, 0);
    }
}
