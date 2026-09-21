using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Character controller reference
    [SerializeField] CharacterController _charControl;
    //Input and direction
    private Vector2 _input;
    [SerializeField] private Vector3 _direction;

    [SerializeField] private float _speed;

    //Variables that smooth turning
    [SerializeField] private float smoothTime = 0.05f;
    private float _currentVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotates player
        ApplyRotation();
        Movement();
    }

    //Faces player to direction being moved
    private void ApplyRotation()
    {
        //Prevents player from facing north whenever nothing is pressed
        if (_input.sqrMagnitude == 0f)
        {
            return;
        }
        //Sets the rotation of player
        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(transform.rotation.x, angle, 0f);
    }

    private void Movement()
    {
        _charControl.Move(_direction * _speed * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        //Checks the movement key pressed and moves in the direction the key was assigned to
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0, _input.y);
    }
}
