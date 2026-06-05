using UnityEngine;

/// <summary>
/// Trigger zone that instructs a FadeWallControlled component to fade in.
/// Used in the Room_Stairway scene as part of the FadeStairs system.
/// When the player enters this trigger, it calls TriggerShow() on the
/// referenced FadeWallControlled instance. Works together with HideZone,
/// which performs the opposite action.
/// </summary>
public class ShowZone : MonoBehaviour
{
    public FadeWallControlled wall;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            wall.TriggerShow();
    }
}
