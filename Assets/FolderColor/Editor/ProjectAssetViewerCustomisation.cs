using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace FolderColor
{
    public class ProjectAssetViewerCustomisation
    {
        [System.Serializable]
        public class AssetModificationData
        {
            public List<string> assetModified = new List<string>();
            public List<string> assetModifiedTexturePath = new List<string>();
        }

        // Reference to the data
        public static AssetModificationData modificationData = new();

        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            LoadData();

            //for each object
            EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemGUI;
        }

        private static void OnProjectWindowItemGUI(string guid, Rect selectionRect)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);

            // Ensure assetType is not null before accessing it
            if (modificationData.assetModified != null && modificationData.assetModified.Contains(assetPath))
            {
                int t = modificationData.assetModified.IndexOf(assetPath);

                Texture2D tex = (Texture2D)AssetDatabase.LoadAssetAtPath(modificationData.assetModifiedTexturePath[t], typeof(Texture2D));

                if (tex == null)
                {
                    modificationData.assetModified.RemoveAt(t);
                    modificationData.assetModifiedTexturePath.RemoveAt(t);
                    SaveData();
                    return;
                }

                if (selectionRect.height == 16) GUI.DrawTexture(new Rect(selectionRect.x + 1.5f, selectionRect.y, selectionRect.height, selectionRect.height), tex);
                else GUI.DrawTexture(new Rect(selectionRect.x, selectionRect.y, selectionRect.height - 10, selectionRect.height - 10), tex);
            }
        }

        // Add a menu item in the Unity Editor to open the custom modification window
        [MenuItem("Assets/Custom Folder", false, 100)]
        private static void CustomModificationMenuItem()
        {
			string[] guids = Selection.assetGUIDs;
			for (int i = 0; i < guids.Length; i++)
			{
				string guid = guids[i];
				string assetPath = AssetDatabase.GUIDToAssetPath(guid);
				if (AssetDatabase.IsValidFolder(assetPath))
				{
					CustomWindowFileImage.ShowWindow(assetPath);
					break;
				}
			}
        }

        // Validate function to enable/disable the menu item
        [MenuItem("Assets/Custom Folder", true)]
        private static bool ValidateCustomModificationMenuItem()
        {
			string[] guids = Selection.assetGUIDs;
			for (int i = 0; i < guids.Length; i++)
			{
				string guid = guids[i];
				string assetPath = AssetDatabase.GUIDToAssetPath(guid);
				if (AssetDatabase.IsValidFolder(assetPath)) return true;
			}

			return false;
		}

        public static void SaveData()
        {
            // Create or update the modificationData
            if (modificationData == null)
            {
                modificationData = new AssetModificationData();
            }

            // Convert to JSON
            string jsonData = JsonUtility.ToJson(modificationData);

			string path = FindScriptPathByName("ProjectAssetViewerCustomisation");
			path = path.Replace("Editor/ProjectAssetViewerCustomisation.cs", "SaveSetUp/FolderModificationData.json");

			File.WriteAllText(path, jsonData);
        }

        private static void LoadData()
        {
			string filePath = FindScriptPathByName("ProjectAssetViewerCustomisation");
			filePath = filePath.Replace("Editor/ProjectAssetViewerCustomisation.cs", "SaveSetUp/FolderModificationData.json");

            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);

                modificationData = JsonUtility.FromJson<AssetModificationData>(jsonData);
            }
        }

		public static string FindScriptPathByName(string scriptName)
		{
			string[] guids = AssetDatabase.FindAssets($"{scriptName} t:script");

			if (guids.Length == 0)
			{
				Debug.LogError($"Script with name '{scriptName}' not found!");
				return null;
			}

			string path = AssetDatabase.GUIDToAssetPath(guids[0]);
			return path;
		}
	}
}