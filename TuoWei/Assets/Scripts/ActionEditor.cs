using UnityEditor;
using UnityEngine;

public class ActionEditorWindow : EditorWindow
{
    static ActionEditorWindow _instance = null;

    //嘿码BLOG网站图标
    Texture2D myIcon = (Texture2D)Resources.Load("icon/logo");

    //窗口连线转折点
    Vector3[] windowToWindowLinePointers = new Vector3[4]{
        Vector3.zero,
        Vector3.zero,
        Vector3.zero,
        Vector3.zero
    };

    //窗口数据结构体
    struct WindowInfo
    {
        public int id;
        public int parentId;
        public string title;
        public Rect rect;
        public Rect dragRect;
        public WindowInfo(int id, int parentId, string title, Rect rect, Rect dragRect)
        {
            this.id = id;
            this.parentId = parentId;
            this.title = title;
            this.rect = rect;
            this.dragRect = dragRect;
        }
    }

    //窗口列表
    WindowInfo[] windowInfos = new WindowInfo[4]{
        new WindowInfo(0, -1, "窗口1", new Rect(0, 0, 150, 100), new Rect(0, 0, 150,20)),
        new WindowInfo(1, 0, "窗口2", new Rect(0, 0, 180, 150), new Rect(0, 0, 180,20)),
        new WindowInfo(2, 0, "窗口3", new Rect(0, 0, 200, 90), new Rect(0, 0, 200,20)),
        new WindowInfo(3, 2, "窗口4", new Rect(0, 0, 120, 200), new Rect(0, 0, 120,20))
    };

    [MenuItem("Qx/ActionEditorWindow")]
    static void Init()
    {
        if (_instance == null)
        {
            _instance = EditorWindow.GetWindow(typeof(ActionEditorWindow)) as ActionEditorWindow;
        }
        _instance.Show();
    }

    void OnDestroy()
    {
        _instance = null;
    }

    void OnGUI()
    {
        BeginWindows();
        Handles.BeginGUI();
        Handles.color = new Color(1f, 0f, 0f, 1f);
        for (int i = 0; i < windowInfos.Length; i++)
        {
            windowInfos[i].rect = GUI.Window(windowInfos[i].id, windowInfos[i].rect, OnWindowGUI, windowInfos[i].title);
            if (windowInfos[i].parentId >= 0 && windowInfos[i].parentId < windowInfos.Length)
            {
                //重绘窗口之间的连线
                if (windowInfos[windowInfos[i].parentId].rect.center.y < windowInfos[i].rect.center.y)
                {
                    windowToWindowLinePointers[0].x = windowInfos[windowInfos[i].parentId].rect.center.x;
                    windowToWindowLinePointers[0].y = windowInfos[windowInfos[i].parentId].rect.center.y + windowInfos[windowInfos[i].parentId].rect.height / 2;

                    windowToWindowLinePointers[1].x = windowToWindowLinePointers[0].x;
                    windowToWindowLinePointers[1].y = windowToWindowLinePointers[0].y + 20;

                    windowToWindowLinePointers[2].x = windowToWindowLinePointers[1].x - (windowInfos[windowInfos[i].parentId].rect.center.x - windowInfos[i].rect.center.x);
                }
                else
                {
                    windowToWindowLinePointers[0].x = windowInfos[i].rect.center.x;
                    windowToWindowLinePointers[0].y = windowInfos[i].rect.center.y - windowInfos[i].rect.height / 2;

                    windowToWindowLinePointers[1].x = windowToWindowLinePointers[0].x;
                    windowToWindowLinePointers[1].y = windowToWindowLinePointers[0].y - 20;

                    windowToWindowLinePointers[2].x = windowToWindowLinePointers[1].x - (windowInfos[i].rect.center.x - windowInfos[windowInfos[i].parentId].rect.center.x);
                }
                windowToWindowLinePointers[2].y = windowToWindowLinePointers[1].y;

                windowToWindowLinePointers[3].x = windowToWindowLinePointers[2].x;
                if (windowInfos[windowInfos[i].parentId].rect.center.y < windowInfos[i].rect.center.y)
                {
                    windowToWindowLinePointers[3].y = windowToWindowLinePointers[2].y + ((windowInfos[i].rect.center.y - windowInfos[i].rect.height / 2) - windowToWindowLinePointers[2].y);
                }
                else
                {
                    windowToWindowLinePointers[3].y = windowToWindowLinePointers[2].y + ((windowInfos[windowInfos[i].parentId].rect.center.y - windowInfos[windowInfos[i].parentId].rect.height / 2) - windowToWindowLinePointers[2].y);
                }

                Handles.DrawPolyLine(windowToWindowLinePointers);
                //重绘窗口顶端的箭头
                Handles.ConeCap(1, new Vector3(windowInfos[i].rect.center.x, windowInfos[i].rect.center.y - windowInfos[i].rect.height / 2 - 8, -10), Quaternion.Euler(new Vector3(-95, 0, 0)), 12);
            }
        }
        Handles.EndGUI();
        EndWindows();
    }

    void OnWindowGUI(int windowID)
    {
        //设置窗口可以拖动
        GUI.DragWindow(windowInfos[windowID].dragRect);
        //设置窗口里面的内容
        GUI.Label(new Rect(windowInfos[windowID].rect.width / 2 - 50, 30, 150, 20), "www.hiwrz.com");
        GUI.DrawTexture(new Rect(windowInfos[windowID].rect.width / 2 - 25, 50, 50, 50), myIcon);
        GUI.Button(new Rect(windowInfos[windowID].rect.width / 2 - 50, windowInfos[windowID].rect.height - 30, 100, 20), "嘿码BLOG");
    }
}