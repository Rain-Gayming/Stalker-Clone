﻿/*           INFINITY CODE          */
/*     https://infinity-code.com    */

using InfinityCode.UltimateEditorEnhancer.PostHeader;
using UnityEditor;
using UnityEngine;

namespace InfinityCode.UltimateEditorEnhancer.HierarchyTools
{
    [InitializeOnLoad]
    public static class NoteDrawer
    {
        static NoteDrawer()
        {
            HierarchyItemDrawer.Register("NoteDrawer", DrawHierarchyItem, HierarchyToolOrder.NOTE);
        }

        private static void DrawHierarchyItem(HierarchyItem item)
        {
            if (EditorApplication.isPlaying) return;
            if (!Prefs.hierarchyNote) return;
            if (item.gameObject == null) return;
            
            NoteItem note;
            NoteManager.TryGetValue(item.gameObject, out note);
            if (note.isEmpty) return;
            
            Rect localRect = new Rect(item.rect);
            localRect.xMin = localRect.xMax - 20;
            item.rect.width -= 22;

            GUIContent content = TempContent.Get(Icons.note, note.text);
            GUI.Label(localRect, content, GUIStyle.none);
        }
    }
}