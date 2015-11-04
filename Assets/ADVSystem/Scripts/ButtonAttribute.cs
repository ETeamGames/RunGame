using UnityEngine;
using System.Reflection;

#if UNITY_EDITOR
using UnityEditor;
#endif

/// Inspector に GUI.Button を表示して、指定された関数を実行するための関数
/// 使用例 [Button("関数名" , "ボタン名")] public int 変数名;
[System.AttributeUsage(System.AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
public sealed class ButtonAttribute : PropertyAttribute
{
    public string buttonFunction;   // 関数名
    public string buttonName;   // ボタンに表示するテキスト

    /// ■■■コンストラクタ■■■
    public ButtonAttribute(string _function, string _name)
    {
        buttonFunction = _function;
        buttonName = _name;
    }
}


/// 上記ボタンアトリビュートをボタン化／および実行するための関数
#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ButtonAttribute))]
public sealed class ButtonDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var buttonAttribute = attribute as ButtonAttribute;

        if (GUI.Button(position, buttonAttribute.buttonName))
        {
            var objectReferenceValue = property.serializedObject.targetObject;
            var type = objectReferenceValue.GetType();
            var bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var method = type.GetMethod(buttonAttribute.buttonFunction, bindingAttr);

            method.Invoke(objectReferenceValue, null);
        }
    }
}
#endif