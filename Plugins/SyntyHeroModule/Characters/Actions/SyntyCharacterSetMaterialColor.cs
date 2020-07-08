using GameCreator.Characters;
using GameCreator.Core;
using UnityEngine;

namespace Synty.GameCreator.Characters
{
    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    
    [AddComponentMenu("")]
    public class SyntyCharacterSetMaterialColor : IAction
    {
        public enum Materials
        {
            primary,
            secondary,
            leatherPrimary,
            leatherSecondary,
            metalPrimary,
            metalSecondary,
            metalDark,
            hair,
            skin,
            stubble,
            scar,
            bodyArt,
            eye
        }
        
        public TargetSyntyCharacter character = new TargetSyntyCharacter();
        public Materials area;
        public Color color = new Color();
        
        // EXECUTABLE: ----------------------------------------------------------------------------

        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
            SyntyCharacter characterTarget = this.character.GetCharacter(target);
            if (characterTarget == null) return true;

            switch (area)
            {
                case Materials.primary:
                    characterTarget.primaryColor = color;
                    break;
                case Materials.secondary:
                    characterTarget.secondaryColor = color;
                    break;
                case Materials.leatherPrimary:
                    characterTarget.leatherPrimaryColor = color;
                    break;
                case Materials.leatherSecondary:
                    characterTarget.leatherSecondaryColor = color;
                    break;
                case Materials.metalPrimary:
                    characterTarget.metalPrimaryColor = color;
                    break;
                case Materials.metalSecondary:
                    characterTarget.metalSecondaryColor = color;
                    break;
                case Materials.metalDark:
                    characterTarget.metalDarkColor = color;
                    break;
                case Materials.hair:
                    characterTarget.hairColor = color;
                    break;
                case Materials.skin:
                    characterTarget.skinColor = color;
                    break;
                case Materials.stubble:
                    characterTarget.stubbleColor = color;
                    break;
                case Materials.scar:
                    characterTarget.scarColor = color;
                    break;
                case Materials.bodyArt:
                    characterTarget.bodyArtColor = color;
                    break;
                case Materials.eye:
                    characterTarget.eyeColor = color;
                    break;
            }
            
            characterTarget.UpdateCharacterVisuals();

            return true;
        }
        
        // +--------------------------------------------------------------------------------------+
        // | EDITOR                                                                               |
        // +--------------------------------------------------------------------------------------+
        
        #if UNITY_EDITOR
        
        public static new string NAME = "Synty Character/Change Material Color";
        private const string NODE_TITLE = "Change color of {0}";
        
        // PROPERTIES: ----------------------------------------------------------------------------
        
        private SerializedProperty spCharacter;
        private SerializedProperty spArea;
        private SerializedProperty spColor;
        
        // INSPECTOR METHODS: ---------------------------------------------------------------------
        
        public override string GetNodeTitle()
        {
            return string.Format(
                NODE_TITLE, 
                this.area.ToString()
            );
        }
        
        protected override void OnEnableEditorChild ()
        {
            this.spCharacter = this.serializedObject.FindProperty("character");
            this.spArea = this.serializedObject.FindProperty("area");
            this.spColor = this.serializedObject.FindProperty("color");
        }
        
        protected override void OnDisableEditorChild ()
        {
            this.spCharacter = null;
            this.spArea = null;
            this.spColor = null;
        }
        
        public override void OnInspectorGUI()
        {
            this.serializedObject.Update();

            EditorGUILayout.PropertyField(this.spCharacter);

            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(this.spArea);
            EditorGUILayout.PropertyField(this.spColor);
            
            this.serializedObject.ApplyModifiedProperties();
        }
        
        #endif
    }
}
