using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UniRx;
using System;
using uTools;

public class MainUI : MonoBehaviour
{
    private static readonly string Exp_Format_ = "{0}/{1}";

    public Text Text_Level_;
    public Text Text_Exp_;
    public Image Image_Exp_;
    public Button Button_Recharge_Gold_;
    public Button Button_Recharge_Jewel_;

    public Toggle[] Toggles_;
    public RectTransform Main_Container_;
    public uTweenPosition Main_Container_Tween_;

    private int current_tab_index_;

    private NotificationManager noti_manager_;

    public void OnValueChanged(bool is_changed)
    {
        if(is_changed)
        {
            int index = Array.FindIndex(Toggles_, (t) => { return t.isOn; });
            if (index.Equals(current_tab_index_)) { return; }
            current_tab_index_ = index;
            Vector3 current_position = Main_Container_.anchoredPosition;
            Vector3 new_position = new Vector3(-(current_tab_index_ * 1080), 0, 0);
            uTweenPosition tp = uTweenPosition.Begin(Main_Container_.gameObject, current_position, new_position);
            tp.method = EaseType.easeOutExpo;
            tp.PlayForward();
        }
    }

    public void CloseHelpWindow() // ReleaseStackedGameObject
    {
        noti_manager_.CloseGameObject();
    }

    public void ShowHelpWindow(GameObject go) // PushGameObjectToStack
    {
        noti_manager_.ShowHelpWindow(go);
    }

    public void ShowPopup(GameObject go) // PushGameObjectToStack
    {
        noti_manager_.ShowPopup(go);
    }


    public void TestLog()
    {
        Debug.Log("Hello Pien");
        ScrollRect s;
    }

    void Awake()
    {
        current_tab_index_ = 2;

        Main_Container_.anchoredPosition = new Vector3(-(current_tab_index_ * 1080), 0, 0);

        Button_Recharge_Gold_.onClick
            .AsObservable()
            .Subscribe(_ =>
            {
                int next_level = System.Convert.ToInt32(Text_Level_.text) + 1;
                Text_Level_.text = next_level.ToString();
            });

        Button_Recharge_Jewel_.OnClickAsObservable()
            .Buffer(3)
            .SubscribeToText(Text_Exp_, _ => _.Count.ToString() + "Clicked");

        ObservableWWW.Get("http://unity-chan.com/")
            .Subscribe(result =>
            {
                Debug.Log(result);
            }, ex =>
            {
                Debug.Log(ex);
            }, () =>
            {
                Debug.Log("Done!");
            });

        //    var clickStream = Observable.EveryUpdate()
        //.Where(_ => Input.GetMouseButtonDown(0));

        //    clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(250)))
        //        .Where(xs => xs.Count >= 2)
        //        .Subscribe(xs => Debug.Log("DoubleClick Detected! Count:" + xs.Count));

        noti_manager_ = NotificationManager.Instance;
    }

    void Start()
    {
        // TODO_ : Sample
        Image_Exp_.fillAmount = 0.6f;
        Text_Level_.text = 1.ToString();
        Text_Exp_.text = string.Format(Exp_Format_, 999, 999);
    }

}
