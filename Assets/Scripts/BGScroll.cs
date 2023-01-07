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

    [Range(0f,1f)]
    public float Scroll;

    void OnEnable()
    {
        Background = GetComponent<RawImage>();
    }

    void Update()
    {
        if (!Background || !CameraTransform) return;
        CameraTransform.position = new Vector3(Mathf.Clamp(CameraTransform.position.x, MinXPos, MaxXPos), 0f, -10f);
        Scroll = (CameraTransform.position.x - MinXPos) / (MaxXPos - MinXPos);

        Background.uvRect = new Rect(Scroll / 2f, 0f, 0.5f, 1f) ;
    }
}
