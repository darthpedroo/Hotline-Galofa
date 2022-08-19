using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    public int MoveSpeed = 6;
    public Vector3 CameraVelocity = Vector3.zero;
    private float LerpFactor = 0.075f;
    private Camera Camera;
    
    // Inicalizacion
    void Start()
    {
      Camera = Camera.main;   
    }

    // Funciones importantes
    public static float GetAngle(float x, float y){
        float value = (float)((Mathf.Atan2(x, y) / 3.14159) * 180f);
        if(value < 0) value += 360f;
    
        return value;
    }

    // Renderizado
    void Update()
    {
        Vector3 MovementVector = new Vector3(0, 0, 0);
        
        if(Input.GetKey("w")) {
            transform.position += new Vector3(0,MoveSpeed*Time.deltaTime, 0);
            MovementVector += new Vector3(0, 1, 0);
        }
        if(Input.GetKey("a")) {
            transform.position += new Vector3(-MoveSpeed*Time.deltaTime, 0, 0);
            MovementVector += new Vector3(-1, 0, 0);
        }
        if(Input.GetKey("s")) {
            transform.position += new Vector3(0,-MoveSpeed*Time.deltaTime, 0);
            MovementVector += new Vector3(0, -1, 0);
        }
        if(Input.GetKey("d")) {
            transform.position += new Vector3(MoveSpeed*Time.deltaTime, 0, 0);
            MovementVector += new Vector3(1, 0, 0);
        }   

        Vector3 MousePosition = Input.mousePosition;

        MousePosition = Camera.ScreenToWorldPoint(new Vector3(MousePosition.x, MousePosition.y, -10));
        MousePosition = MousePosition - transform.position;

        Vector3 DesiredPos = gameObject.transform.position + MovementVector;
        Vector3 CamPos = Vector3.SmoothDamp(Camera.transform.position, transform.position, ref CameraVelocity, LerpFactor);
        Quaternion GoalRotation = Quaternion.Euler(0, 0, -GetAngle(MousePosition.x, MousePosition.y));

        transform.rotation = GoalRotation;
        Camera.transform.position = CamPos - new Vector3(0, 0, 1);
    }
}
