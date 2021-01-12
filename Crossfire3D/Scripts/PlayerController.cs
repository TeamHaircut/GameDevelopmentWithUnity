using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int ballSpeed = 1000;
    public GameObject ball;
    public GameObject nozzle;

    private Rigidbody rb;
    private float rotationSpeed = 200.0f;//shooter rotation speed
    private float movementX;
    private float movementY;
    private InputAction fireAction;

    private void Awake()
    {
        var actions = GetComponent<PlayerInput>().actions;
        fireAction = actions.FindAction("Fire");
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnFire()
    {
        GameObject bullet = Instantiate(ball, nozzle.transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(nozzle.transform.forward * ballSpeed);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void Update()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        if(!(transform.rotation.y <= -0.4f && movementX < 0.0f) && !(transform.rotation.y >= 0.4f && movementX > 0.0f))
        {
            transform.Rotate(Vector3.up, rotationSpeed * movementX * Time.deltaTime);
        }

    }

}