using UnityEngine;
using System.Collections;
using uTools;

public class PopupCardBuy : MonoBehaviour
{
    public uTweenScale Tween_Scale_;

    public RectTransform Close_Button_;

    void OnEnable()
    {
        Tween_Scale_.enabled = true;
    }

    void OnDisable()
    {
        Close_Button_.localScale = Vector3.one;
    }
}
