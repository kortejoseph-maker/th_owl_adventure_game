using UnityEngine;

/// <summary>
/// Trigger zone that instructs a FadeWallControlled component to fade out.
/// Used in the Room_Stairway scene as part of the FadeStairs system.
/// When the player enters this trigger, it calls TriggerHide() on the
/// referenced FadeWallControlled instance. Works together with ShowZone,
/// which fades the object back in.
/// </summary>
public class HideZone : MonoBehaviour
{
    public FadeWallControlled wall;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            wall.TriggerHide();
    }
}
