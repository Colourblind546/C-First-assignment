using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{

    GameObject player;

    Vector3 cameraDisplace;
    [SerializeField] float maxDisplaceDistance;
    Vector2 mousePosition;

    [SerializeField] InputAction mouseAndRStick;

    private void Awake()
    {
        if (player == null)
        {
            player = FindPlayer();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementCode();
    }

    /// <summary>
    /// The meat and potatoes, this moves the camera
    /// </summary>
    void MovementCode()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - player.transform.position; // Gets the mouse position in the world minus the player position to account for moving around
        Debug.Log(mousePosition);
        //mousePosition 

        cameraDisplace = new Vector2(mousePosition.x, mousePosition.y);
        cameraDisplace /= Vector2.Distance(cameraDisplace, Vector2.zero); // DO THIS NEXT TIME, MAKE IT LIMIT THE RANGE OF THE MAX OFFSET FOR THE CAMERA TO MAKE THE OUTER BOUNDS BE A CIRCLE INSTEAD OF A SQUARE

        transform.position = player.transform.position + (cameraDisplace / 15) + Vector3.back * 15;
    }

    /// <summary>
    /// Finds the player object in the scene and returns it
    /// </summary>
    /// <returns></returns>
    GameObject FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            return player;
        }
        else
        {
            return null;
        }
    }
}
