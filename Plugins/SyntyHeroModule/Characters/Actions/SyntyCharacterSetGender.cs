using GameCreator.Characters;
using GameCreator.Core;
using Synty.GameCreator.Characters;
using UnityEditor;
using UnityEngine;

namespace Synty.GameCreator.Characters
{
    [AddComponentMenu("")]
    public class SyntyCharacterSetGender : IAction
    {
        public TargetSyntyCharacter character = new TargetSyntyCharacter();
        
        public SyntyCharacter.EnumGender gender = SyntyCharacter.EnumGender.Male;

        // EXECUTABLE: ----------------------------------------------------------------------------
        
        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
            SyntyCharacter characterTarget = this.character.GetCharacter(target);
            if (characterTarget == null) return true;

            characterTarget.gender = this.gender;
            
            characterTarget.UpdateCharacterVisuals();

            return true;
        }
        
        // +--------------------------------------------------------------------------------------+
        // | EDITOR                                                                               |
        // +--------------------------------------------------------------------------------------+
        
        #if UNITY_EDITOR
        
        public static new string NAME = "Synty Character/Synty Character Set Gender";
        private const string NODE_TITLE = "Set character gender to {0}";
        
        // PROPERTIES: ----------------------------------------------------------------------------
        
        private SerializedProperty spCharacter;
        
        private SerializedProperty spGender;

        // INSPECTOR METHODS: ---------------------------------------------------------------------
        
        public override string GetNodeTitle()
        {
            return string.Format(
                NODE_TITLE, 
                this.gender.ToString()
            );
        }
        
        protected override void OnEnableEditorChild ()
        {
            this.spCharacter = this.serializedObject.FindProperty("character");

            this.spGender = this.serializedObject.FindProperty("gender");
        }
        
        protected override void OnDisableEditorChild ()
        {
            this.spCharacter = null;

            this.spGender = null;
        }
        
        public override void OnInspectorGUI()
        {
            this.serializedObject.Update();

            EditorGUILayout.PropertyField(this.spCharacter);

            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(this.spGender);

            this.serializedObject.ApplyModifiedProperties();
        }
        
        #endif
    }
}


