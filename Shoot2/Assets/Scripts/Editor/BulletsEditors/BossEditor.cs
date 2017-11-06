using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace BulletsGenerator
{
    [CustomEditor(typeof(Boss))]
    public class BossEditor : 
        EditorWithSubEditors<BulletsWaveEditor,BulletsWave>
    {
        private Boss boss;

        private SerializedProperty bossLocationProperty;
        private SerializedProperty bossProperty;

        private const float bulletsWaveButtonWidth = 125f;

        private const string bossPropName = "boss";
        private const string bossPropBulletsWaveName = "bulletsWaveCollected";

        private void OnEnable()
        {
            boss = (Boss)target;

            bossLocationProperty = serializedObject.FindProperty(bossPropName);
            bossProperty = serializedObject.FindProperty(bossPropBulletsWaveName);

            CheckAndCreateSubEditors(boss.bulletsWaveCollected);
        }

        private void OnDisable()
        {
            CleanupEditors();
        }

        protected override void SubEditorSetup(BulletsWaveEditor editor)
        {
            editor.bossProperty = bossProperty;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            CheckAndCreateSubEditors(boss.bulletsWaveCollected);

            EditorGUILayout.PropertyField(bossLocationProperty);

            for (int i = 0; i<subEditors.Length;i++)
            {
                subEditors[i].OnInspectorGUI();
                EditorGUILayout.Space();
            }

            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Add Collection", GUILayout.Width(bulletsWaveButtonWidth)))
            {
                BulletsWave newBulletsWave = BulletsWaveEditor.CreateBulletsWave();
                bossProperty.AddToObjectArray(newBulletsWave);
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}