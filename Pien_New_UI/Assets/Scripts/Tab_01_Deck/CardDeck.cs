using UnityEngine;
using System.Collections;
using uTools;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardDeck : MonoBehaviour {
    public uTweenPosition Tab_Tween_Position_;
    public ToggleGroup Tab_Toggle_Group_;

    public void MoveTabCover(Toggle t)
    {
        if(t.isOn)
        {
            Tab_Tween_Position_.to = t.GetComponent<RectTransform>().anchoredPosition;
            Tab_Tween_Position_.enabled = true;
        }else
        {
            Tab_Tween_Position_.from = t.GetComponent<RectTransform>().anchoredPosition;
            Tab_Tween_Position_.ResetToBeginning();
        }
    }

    void Awake()
    {

    }
}
