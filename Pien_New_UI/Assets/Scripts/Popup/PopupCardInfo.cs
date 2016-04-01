using UnityEngine;
using System.Collections;
using uTools;

public class PopupCardInfo : MonoBehaviour {

    public uTweenScale Tween_Scale_;

    void OnEnable()
    {
        Tween_Scale_.enabled = true;
    }
}
