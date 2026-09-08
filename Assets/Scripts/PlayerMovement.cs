using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement stuff")]
    [SerializeField] Vector3 move;
    [SerializeField] Vector3 modifiedMove;
    public float moveSpeed;

    [Header("Input Actions")]
    [SerializeField] InputActionReference movementAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (movementAction != null)
        {
            Debug.Log("IS MOVEMENT ACTION NULL?!!!!");
            move = movementAction.action.ReadValue<Vector2>();
        }
        Debug.Log($"HERE'S THE FUCKIN MOVE VALUE: {move}");

        modifiedMove = move * Time.deltaTime * moveSpeed;
        Debug.Log($"HERE'S THE FUCKIN MODIFIED MOVE VALUE TOO: {modifiedMove}");

        transform.position += new Vector3(modifiedMove.x, 0, 0);
        transform.position += new Vector3(0, modifiedMove.y, 0);
    }
}
