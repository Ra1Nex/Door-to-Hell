


// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using Unity.Burst.CompilerServices;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public float interactionRange = 2f;
    [SerializeField] private Camera _mainCamera;
    public bool IsButtonActive = false;
    public Animator animator;
    private void Start()
    {
        GameObject[] lights = GameObject.FindGameObjectsWithTag("light");
        foreach (GameObject lightObject in lights)
        {
            Light lightComponent = lightObject.GetComponent<Light>();
            if (lightComponent != null)
            {
                Debug.Log("Disabling light: " + lightObject.name);
                lightComponent.enabled = false;
            }
            else
            {
                Debug.LogWarning("No Light component found on object: " + lightObject.name);
            }
        }
    }

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
        Debug.Log("Interacted : " + obj.name);
        GameObject[] lights = GameObject.FindGameObjectsWithTag("light");
        foreach (GameObject lightObject in lights)
        {
            Light lightComponent = lightObject.GetComponent<Light>();
            if (lightComponent != null)
            {
                Debug.Log("enabling light: " + lightObject.name);
                lightComponent.enabled = true;
            }
        }

        IsButtonActive = true;
    }
}