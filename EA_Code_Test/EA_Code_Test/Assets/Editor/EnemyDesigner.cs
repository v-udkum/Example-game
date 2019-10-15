using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyDesigner : EditorWindow
{
    Texture2D headerSectionTexture;
    Texture2D mageSectionTexture;
    Texture2D warriorSectionTexture;
    Texture2D rougeSectionTexture;
    Color headerSectionColor = new Color(13f / 255f, 32f / 255f, 44f / 255f, 1f);

    Rect headerSection;
    Rect mageSection;
    Rect warriorSection;
    Rect rougeSection;

    [MenuItem("Window/EnemyDesigner")]
    static void OpenWindow()
    {
        EnemyDesigner Window = (EnemyDesigner)GetWindow<EnemyDesigner>();
        Window.minSize = new Vector2(600, 300);
        Window.Show();
        
    }
    private void OnEnable()
    {
        InitTextures();
    }

   void InitTextures()
    {
        headerSectionTexture = new Texture2D(1, 1);
        headerSectionTexture.SetPixel(0, 0, headerSectionColor);
        headerSectionTexture.Apply();

        mageSectionTexture = Resources.Load<Texture2D>("Icon/Blue");
        rougeSectionTexture = Resources.Load<Texture2D>("Icon/Green");
        warriorSectionTexture = Resources.Load<Texture2D>("Icon/Orange");
    }

    private void OnGUI()
    {
        Drawheader();
        DrawLayouts();
        DrawMageSettings();
        DrawWarriorSettings();
        DrawRogueSettings();
        
    }
    void DrawLayouts()
    {
        headerSection.x =0;
        headerSection.y = 0;
        headerSection.width = Screen.width;
        headerSection.height = 50;
       

       mageSection.x = 0;
        mageSection.y = 50;
        mageSection.width = Screen.width/3f;
        mageSection.height = Screen.width-50;

        rougeSection.x = Screen.width / 3f;
        rougeSection.y = 50;
        rougeSection.width = Screen.width / 2f;
        rougeSection.height = Screen.width - 50;

        warriorSection.x = (Screen.width / 3f)*2;
        warriorSection.y = 50;
        warriorSection.width = Screen.width / 2f;
        warriorSection.height = Screen.width - 50;

        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(mageSection, mageSectionTexture);
        GUI.DrawTexture(rougeSection, rougeSectionTexture);
        GUI.DrawTexture(warriorSection, warriorSectionTexture);
 
    }
    void Drawheader()
    {
        GUILayout.BeginArea(headerSection);

        GUILayout.EndArea();
    }
    void DrawMageSettings()
    {

    }
    void DrawWarriorSettings()
    {

    }
    void DrawRogueSettings()
    {

    }


}
