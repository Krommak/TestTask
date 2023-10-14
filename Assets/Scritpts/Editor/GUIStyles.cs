using UnityEngine;

public static class GUIStyles
{
    static GUIStyles()
    {
        MiniButton = new GUIStyle(UnityEditor.EditorStyles.miniButton);
        MiniButton.fixedWidth = 20;
        MiniButton.alignment = TextAnchor.MiddleCenter;
        MiniButton.fontStyle = FontStyle.Bold;

        SmallButton = new GUIStyle("Button");
        SmallButton.fixedWidth = 110;
        SmallButton.alignment = TextAnchor.MiddleCenter;

        MiddleButton = new GUIStyle("Button");
        MiddleButton.fixedWidth = 200;
        MiddleButton.alignment = TextAnchor.MiddleCenter;

        LableText = new GUIStyle("Label");
        LableText.alignment = TextAnchor.MiddleCenter;
        LableText.fontStyle = FontStyle.Bold;
        
        TitleText = new GUIStyle("Label");
        TitleText.normal.textColor = Color.white;
        TitleText.fontSize = 15;
        TitleText.alignment = TextAnchor.MiddleCenter;
        TitleText.fontStyle = FontStyle.Bold;

        NormalBox = new GUIStyle("Box");
        NormalBox.alignment = TextAnchor.MiddleCenter;
    }

    public static GUIStyle MiniButton;

    public static GUIStyle SmallButton;

    public static GUIStyle MiddleButton;

    public static GUIStyle LableText;

    public static GUIStyle TitleText;

    public static GUIStyle MiddleText;

    public static GUIStyle NormalBox;
}