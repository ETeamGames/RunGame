using UnityEngine;
using UnityEditor; // エディタ拡張関連はUnityEditor名前空間に定義されているのでusingしておく。
using System.Collections.Generic;
using UnityEditorInternal;

[CanEditMultipleObjects]
[CustomEditor(typeof(SceneManager))]
public class ScenarioEditorWindow : Editor
{
    ReorderableList rl;

    public override void OnInspectorGUI()
    {
        // とりあえず元のプロパティ表示はしておく
        DrawDefaultInspector();

        serializedObject.Update();
        DrawProperties();
        serializedObject.ApplyModifiedProperties();
    }

    private void OnEnable()
    {
        // SerializedPropertyの値を取得
        // 最初の取得時には何故か null が返って来るので1度適当な値で読む
        serializedObject.FindProperty("__dummy__");
        rl = new ReorderableList(serializedObject,serializedObject.FindProperty("scenario"),true, true, true, true);

        rl.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
            var element = rl.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            EditorGUI.LabelField(new Rect(rect.x, rect.y, 60, EditorGUIUtility.singleLineHeight),"名前");
            EditorGUI.PropertyField(new Rect(rect.x * 2, rect.y, 60, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("charaName"), GUIContent.none);
            EditorGUI.LabelField(new Rect(rect.x, rect.y+20, 60, EditorGUIUtility.singleLineHeight), "内容");
            EditorGUI.PropertyField(new Rect(rect.x+35, rect.y+5, rect.width - 60 - 30, EditorGUIUtility.singleLineHeight*5), element.FindPropertyRelative("text"), GUIContent.none);
        };
        rl.elementHeight = EditorGUIUtility.singleLineHeight * 6;
    }

    //各要素の描画
    void DrawProperties()
    {
        rl.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}