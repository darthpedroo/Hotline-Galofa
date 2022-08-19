using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public float MoveSpeed = 18f;
    public Vector3 CameraVelocity = Vector3.zero;
    private float LerpFactor = 0.125f;
    private Camera Camera;
    public Animator animator;
    public bool IsPressed = false;

    // Funciones importantes
    public static float GetAngle(float x, float y){
        float value = (float)((Mathf.Atan2(x, y) / 3.14159) * 180f);
        if(value < 0) value += 360f;
    
        return value;
    }

    void Start()
    {
        Camera = Camera.main;   
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        IsPressed = false;
        Vector3 MovementVector = new Vector3(0, 0, 0);

        if(Input.GetKey("d")) {
            transform.position += new Vector3(MoveSpeed*Time.deltaTime, 0, 0);
            MovementVector += new Vector3(1, 0, 0);
            IsPressed = true;
        }   
        if(Input.GetKey("w")) {
            transform.position += new Vector3(0,MoveSpeed*Time.deltaTime, 0);
            MovementVector += new Vector3(0, 1, 0);
            IsPressed = true;
        }
        if(Input.GetKey("s")) {
            transform.position += new Vector3(0,-MoveSpeed*Time.deltaTime, 0);
            MovementVector += new Vector3(0, -1, 0);
            IsPressed = true;
        }
        if(Input.GetKey("a")) {
            transform.position += new Vector3(-MoveSpeed*Time.deltaTime, 0, 0);
            MovementVector += new Vector3(-1, 0, 0);
            IsPressed = true;
        }

       
        animator.SetBool("IsMoving", IsPressed);

        Vector3 MousePosition = Input.mousePosition;

        MousePosition = Camera.ScreenToWorldPoint(new Vector3(MousePosition.x, MousePosition.y, -7));
        MousePosition = MousePosition - transform.position;

        Vector3 DesiredPos = gameObject.transform.position + MovementVector;
        Vector3 CamPos = Vector3.SmoothDamp(Camera.transform.position, transform.position, ref CameraVelocity, LerpFactor);
        Quaternion GoalRotation = Quaternion.Euler(0, 0, -GetAngle(MousePosition.x, MousePosition.y));

        transform.rotation = GoalRotation;
        Camera.transform.position = CamPos - new Vector3(0, 0, 1);
    }
}
