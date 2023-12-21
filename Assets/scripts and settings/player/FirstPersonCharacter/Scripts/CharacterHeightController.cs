// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using UnityEngine;

public class CharacterHeightController : MonoBehaviour
{
    public float standingHeight = 1.6f;
    public float crouchingHeight = 0.9f;
    private CharacterController characterController;
    private bool isCrouching = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("CharacterController не найден!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            isCrouching = !isCrouching; 
            characterController.height = isCrouching ? crouchingHeight : standingHeight;
        }
    }
}
