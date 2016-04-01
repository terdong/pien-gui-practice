using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NotificationManager : Singleton<NotificationManager> {

    private Stack<GameObject> activated_stack_;

    public void ShowPopup(GameObject go) // PushGameObjectToStack
    {
        //if (go.activeSelf) { CloseHelpWindow(); return; }
        //else { CloseHelpWindow(); }

        activated_stack_.Push(go);
        go.SetActive(true);
        PrintStackCount();
    }

    public void ShowHelpWindow(GameObject go) // PushGameObjectToStack
    {
        if (go.activeSelf) { CloseGameObject(); return; }
        else { CloseGameObject(); }

        activated_stack_.Push(go);
        go.SetActive(true);
        PrintStackCount();
    }

    public void CloseGameObject() // ReleaseStackedGameObject
    {
        if (activated_stack_.Count > 0)
        {
            activated_stack_.Pop().SetActive(false);
            PrintStackCount();
        }
    }

    private void PrintStackCount()
    {
        Debug.LogFormat("activated_stack_.Count = {0}", activated_stack_.Count);
    }

    void Awake()
    {
        activated_stack_ = new Stack<GameObject>();
    }

    void OnDisabled()
    {
        IEnumerator<GameObject> e = activated_stack_.GetEnumerator();
        for(;e.MoveNext();)
        {
            e.Current.SetActive(false);
        }
        activated_stack_.Clear();
        activated_stack_ = null;
    }

}
