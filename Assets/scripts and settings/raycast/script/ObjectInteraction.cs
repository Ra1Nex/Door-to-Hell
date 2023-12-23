using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public float interactionRange = 2f;
    public bool IsButtonActive = false;
    public Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, interactionRange))
            {
                if (hit.collider.CompareTag("Panel"))
                {
                    InteractWithObject(hit.collider.gameObject);
                }
                if (hit.collider.CompareTag("Button") && IsButtonActive) 
                {
                    animator.SetBool("IsOpen", true);
                }
                if (hit.collider.CompareTag("Butto2") && IsButtonActive)
                {
                    animator.SetBool("IsOpen", false);
                }
            }
        }
    }

    void InteractWithObject(GameObject obj)
    {
        Debug.Log("Interacted with: " + obj.name);
        IsButtonActive = true;
    }
}
