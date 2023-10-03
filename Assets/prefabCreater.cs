using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class prefabCreater : MonoBehaviour
{

    [SerializeField] private GameObject dragonprefab;
    [SerializeField] private Vector3 prefabOffSet;

    private GameObject dragon;
    private ARTrackedImageManager artrackedImageManager;

    private void OnEnable()
    {
        artrackedImageManager =gameObject.GetComponent<ARTrackedImageManager>();
        artrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            dragon = Instantiate(dragonprefab, image.transform);
            dragon.transform.position += prefabOffSet;
        }
    }
        
}
