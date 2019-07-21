﻿using UnityEditor;
using UnityEngine;

namespace WizardsCode.Tools.DocGen
{
    [CustomPropertyDrawer(typeof(DocGenAttribute), true)]
    public class DocGenAttributeDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float totalHeight = base.GetPropertyHeight(property, label);

            return totalHeight;
        }
        private float DescriptionHeight
        {
            get { return EditorGUIUtility.singleLineHeight * 3; }
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            DocGenAttribute docgen = attribute as DocGenAttribute;
            Rect fieldRect = new Rect(position);

            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.PropertyField(fieldRect, property, label, true);

            property.isExpanded = EditorGUI.Foldout(fieldRect, property.isExpanded, GUIContent.none, true);

            if (!property.isExpanded)
            {
                EditorGUI.EndProperty();
                return;
            }

            EditorGUILayout.HelpBox(docgen.Description, MessageType.Info);

            EditorGUI.EndProperty();
        }
    }
}