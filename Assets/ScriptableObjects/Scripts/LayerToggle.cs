using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Switches the sprite's sorting layer between background and foreground.
/// Used in the Room_Stairway scene on the LayerToggleStairs object.
/// 
/// ForegroundZone and BackgroundZone can switch the sorting layer externally,
/// but this component can also switch layers automatically if the object
/// itself has a trigger collider. Entering the collider switches to the
/// foreground layer, leaving it switches back to the background layer.
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class LayerToggle : MonoBehaviour
{
    [Header("Sorting Layer Settings")]
    public string backgroundSortingLayer = "Background";
    public string foregroundSortingLayer = "Fade";

    private SpriteRenderer _sr;

    void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void TriggerBackground()
    {
        _sr.sortingLayerName = backgroundSortingLayer;
    }

    public void TriggerForeground()
    {
        _sr.sortingLayerName = foregroundSortingLayer;
    }
    
    // automatic switching if this object has its own trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            TriggerForeground();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            TriggerForeground();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            TriggerBackground();
    }

}
