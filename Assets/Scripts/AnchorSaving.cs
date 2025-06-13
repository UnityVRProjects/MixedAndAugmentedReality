using UnityEngine;
using System.Threading.Tasks;

public class AnchorSaving : MonoBehaviour
{
    private OVRSpatialAnchor anchor;

    async void Start()
    {
        anchor = GetComponent<OVRSpatialAnchor>();

        if (anchor == null)
        {
            Debug.LogError("OVRSpatialAnchor not found!");
            return;
        }

        // Wait until the anchor is created and localized
        bool success = await anchor.WhenLocalizedAsync();
        Debug.Log($"Anchor localized: {success}");

        if (success)
        {
            var result = await anchor.SaveAnchorAsync();
            Debug.Log($"Anchor save result: {result.Status}");
        }
    }
}
