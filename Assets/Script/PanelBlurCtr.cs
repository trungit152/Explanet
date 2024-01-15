using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBlurCtr : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    private void Start()
    {
        canvasGroup.alpha = 0.5f;
    }
}
