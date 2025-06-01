using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class OneTimeTrackedImageSpawner : MonoBehaviour
{
    public ARTrackedImageManager imageManager;
    public GameObject prefabToSpawn;
    private GameObject spawnedObject;
    private bool hasSpawned = false;

    void OnEnable()
    {
        imageManager.trackedImagesChanged += OnImageChanged;
    }

    void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            TrySpawn(trackedImage);
        }

        foreach (var trackedImage in args.updated)
        {
            TrySpawn(trackedImage);
        }
    }

    private void TrySpawn(ARTrackedImage trackedImage)
    {
        if (!hasSpawned && trackedImage.trackingState == TrackingState.Tracking)
        {
            // Optional: Offset to lift prefab slightly
            Vector3 offset = new Vector3(0, 0.05f, 0);

            spawnedObject = Instantiate(prefabToSpawn, trackedImage.transform.position + offset, trackedImage.transform.rotation);
            hasSpawned = true;
        }
    }
}
