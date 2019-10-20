using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class TexturePacker : EditorWindow
{
    bool buttonPressed = false;
    bool buttonAtlas = false;

    [SerializeField]
    private List<Texture2D> palette = new List<Texture2D>();

    [SerializeField]
    private int paletteIndex;

    private string path = "Assets/Textures";
    [MenuItem("Tools/Texture Packer")]
    private static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(TexturePacker));
    }

    // Called to draw the MapEditor windows.
    private void OnGUI()
    {
        buttonPressed = GUILayout.Toggle(buttonPressed, "Load Images", "Button", GUILayout.Height(60f));


        if (buttonPressed)
        {
            // Get a list of previews, one for each of our images
            List<GUIContent> paletteIcons = new List<GUIContent>();
            foreach (Texture2D image in palette)
            {
                // Get a preview for the images
                Texture2D texture = AssetPreview.GetAssetPreview(image);
                paletteIcons.Add(new GUIContent(texture));
            }

            // Display the grid
            paletteIndex = GUILayout.SelectionGrid(paletteIndex, paletteIcons.ToArray(), 6);

            buttonAtlas = GUILayout.Button("Atlas Prepare", GUILayout.Height(30f));
            if (buttonAtlas)
            {
                AtlasMaker.NewAtlas();
            }
        }

        

    }


    void OnFocus()
    {
      RefreshPalette();
    }

    private void RefreshPalette()
    {
       palette.Clear();

        string[] imageFiles = System.IO.Directory.GetFiles(path, "*.png");
        foreach (string imageFile in imageFiles)
            palette.Add(AssetDatabase.LoadAssetAtPath(imageFile, typeof(Texture2D)) as Texture2D);
    }

    
}

