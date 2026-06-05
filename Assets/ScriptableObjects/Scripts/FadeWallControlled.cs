using System.Collections;
using UnityEngine;

/// <summary>
/// Controls the fade-in and fade-out behavior of a sprite.
/// Used in the Room_Stairway scene on the FadeStairs object.
/// 
/// This is the externally controlled version of the fading system.
/// Unlike FadeWall (the automatic trigger-based variant), this script
/// does not react to trigger events on its own. Instead, it is driven
/// by the HideZone and ShowZone scripts, which call TriggerHide() and
/// TriggerShow() when the player enters specific trigger areas.
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class FadeWallControlled : MonoBehaviour
{
    [Range(0f, 1f)] public float visibleAlpha = 1f;
    [Range(0f, 1f)] public float hiddenAlpha = 0f;
    public float fadeDuration = 0.25f;

    private SpriteRenderer _sr;
    private Coroutine _fadeCoroutine;

    void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void TriggerHide()
    {
        Fade(hiddenAlpha);
    }

    public void TriggerShow()
    {
        Fade(visibleAlpha);
    }

    private void Fade(float targetAlpha)
    {
        if (_fadeCoroutine != null) StopCoroutine(_fadeCoroutine);
        _fadeCoroutine = StartCoroutine(FadeRoutine(targetAlpha));
    }

    private IEnumerator FadeRoutine(float targetAlpha)
    {
        float startAlpha = _sr.color.a;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            Color c = _sr.color;
            c.a = Mathf.Lerp(startAlpha, targetAlpha, elapsed / fadeDuration);
            _sr.color = c;
            yield return null;
        }

        Color final = _sr.color;
        final.a = targetAlpha;
        _sr.color = final;
    }
}
