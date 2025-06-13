using UnityEngine;
using System.Threading.Tasks;

public class AnchorPlacer : MonoBehaviour
{
    public GameObject anchorVisualPrefab; // a cube or marker prefab to attach

    void Update()
    {
        // Trigger anchor creation with a key or controller input
        if (Input.GetKeyDown(KeyCode.Space) || OVRInput.GetDown(OVRInput.Button.One))
        {
            TryPlaceAnchor();
        }
    }

    async void TryPlaceAnchor()
    {
        // Raycast from center of view
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 anchorPosition = hitInfo.point;

            // Create a GameObject at the hit point
            GameObject obj = Instantiate(anchorVisualPrefab, anchorPosition, Quaternion.identity);

            // Add and localize anchor
            var anchor = obj.AddComponent<OVRSpatialAnchor>();
            bool localized = await anchor.WhenLocalizedAsync();

            if (localized)
            {
                var result = await anchor.SaveAnchorAsync();
                Debug.Log("Anchor placed and saved at " + anchorPosition);
            }
        }
        else
        {
            Debug.Log("No surface hit. Aim at a collider.");
        }
    }

    public void CreateSpatialAnchor()
    {
        GameObject prefab = Instantiate(anchorVisualPrefab, OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch), OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch));
        prefab.AddComponent<OVRSpatialAnchor>();
    }
}

