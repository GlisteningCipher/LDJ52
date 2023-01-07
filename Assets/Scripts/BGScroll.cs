// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class BGScroll : MonoBehaviour
{
    [SerializeField] RawImage Background;
    [SerializeField] Transform CameraTransform;
    [SerializeField] float MinXPos;
    [SerializeField] float MaxXPos;
    [SerializeField] float ScreensWide = 1f;

    [Range(0f,1f)]
    public float Scroll;

    void OnEnable()
    {
        Background = GetComponent<RawImage>();
    }

    void Update()
    {
        if (!Background) return;

        if (CameraTransform)
            Scroll = (CameraTransform.position.x - MinXPos) / (MaxXPos - MinXPos);

        var width = 1 / ScreensWide;
        Background.uvRect = new Rect((1-width) * Scroll, 0f, width, 1f);
    }
}
