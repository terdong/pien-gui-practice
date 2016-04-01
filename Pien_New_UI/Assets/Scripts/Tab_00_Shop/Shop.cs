using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {
    private NotificationManager noti_manager_;

    public void CloseBuyPopup() 
    {
        noti_manager_.CloseGameObject();
    }

    public void ShowBuyPopup(GameObject go) 
    {
        noti_manager_.ShowPopup(go);
    }

    void Awake()
    {
        noti_manager_ = NotificationManager.Instance;
    }
}
