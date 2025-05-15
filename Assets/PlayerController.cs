using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
<<<<<<< HEAD
        
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

       
        Vector3 move = new Vector3(moveX, 0, moveZ);

        
=======
        // Get input from keyboard (WASD or arrow keys)
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // Create a movement vector based on input
        Vector3 move = new Vector3(moveX, 0, moveZ);

        // Move the player using CharacterController component
>>>>>>> b15ae4d7a7033609add3b6fa805f50e4913641f5
        GetComponent<CharacterController>().Move(move);
    }
}
