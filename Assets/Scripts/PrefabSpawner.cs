using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabSpawner : MonoBehaviour
{
	[SerializeField] private GameObject bearPrefab;
	[SerializeField] private Vector3 prefabOffset;

	private GameObject bear;
	private ARTrackedImageManager aRTrackedImageManager;

	private void OnEnabled()
	{
		aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();
		aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
	}

	private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
	{
		foreach (ARTrackedImage image in obj.added)
		{
			bear = Instantiate(bearPrefab, image.transform);
			bear.transform.position += prefabOffset;
		}
	}
}
