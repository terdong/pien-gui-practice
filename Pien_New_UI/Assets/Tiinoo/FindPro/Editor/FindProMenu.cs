using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Tiinoo.FindPro
{
	public class FindProMenu
	{
		[MenuItem("Window/Tiinoo/Find Pro/Find Asset References...")]
		private static void FindAssetReferences()
		{
			EditorWindow.GetWindow<WindowFindAssetReferences>(false, "Find Asset References", true);
		}
		
		[MenuItem("Window/Tiinoo/Find Pro/Find Missing References...")]
		private static void FindMissingReferences()
		{
			EditorWindow.GetWindow<WindowFindMissingReferences>(false, "Find Missing References", true);
		}

		[MenuItem("Assets/Find Asset References...", false, 81)]
		private static void QuickFindAssetReferences()
		{
			WindowFindAssetReferences window = EditorWindow.GetWindow<WindowFindAssetReferences>(false, "Find Asset References", true);
			window.SetTarget(Selection.activeObject);
		}

		[MenuItem("Assets/Find Asset References...", true)]
		private static bool QuickFindAssetReferencesValidate()
		{
			Object obj = Selection.activeObject;
			if (obj == null)
			{
				return false;
			}

			bool isValid = WindowFindAssetReferences.CheckTarget(obj, false);
			return isValid;
		}

		[MenuItem("Assets/Find Missing References...", false, 82)]
		private static void QuickFindMissingReferences()
		{
			EditorWindow.GetWindow<WindowFindMissingReferences>(false, "Find Missing References", true);
		}
	}
}

