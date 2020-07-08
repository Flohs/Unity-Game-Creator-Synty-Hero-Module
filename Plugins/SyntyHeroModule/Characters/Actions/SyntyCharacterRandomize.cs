using GameCreator.Characters;
using GameCreator.Core;
using UnityEngine;

namespace Synty.GameCreator.Characters
{
    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    
    [AddComponentMenu("")]
    public class SyntyCharacterRandomize : IAction
    {
        public TargetSyntyCharacter character = new TargetSyntyCharacter();
        
        // EXECUTABLE: ----------------------------------------------------------------------------

        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
            SyntyCharacter characterTarget = this.character.GetCharacter(target);
            if (characterTarget == null) return true;

            int eyebrowsIndex = Random.Range(0, characterTarget.eyebrowTotal);
            int headIndex = Random.Range(0, characterTarget.headAllElementsTotal);
            int hairIndex = Random.Range(0, characterTarget.hairTotal);
            int facialHairIndex = Random.Range(0, characterTarget.facialHairTotal);

            characterTarget.eyebrowIndex = eyebrowsIndex;
            characterTarget.headAllElementsIndex = headIndex;
            characterTarget.hairIndex = hairIndex;

            if (characterTarget.gender == SyntyCharacter.EnumGender.Male)
                characterTarget.facialHairIndex = facialHairIndex;

            #region skin color

            int skinColorRange = Random.Range(1, 5);
            if (skinColorRange == 5)
            {
                characterTarget.skinColor = new Color(1f, 0.8f, 0.68f);
                characterTarget.scarColor = new Color(0.93f, 0.69f, 0.59f);
                characterTarget.stubbleColor = new Color(0.8f, 0.7f, 0.63f);
            } 
            else if (skinColorRange == 4)
            {
                characterTarget.skinColor = new Color(0.82f, 0.64f, 0.46f);
                characterTarget.scarColor = new Color(0.7f, 0.55f, 0.4f);
                characterTarget.stubbleColor = new Color(0.66f, 0.57f, 0.46f);
            }
            else if (skinColorRange == 3)
            {
                characterTarget.skinColor = new Color(0.56f, 0.41f, 0.31f);
                characterTarget.scarColor = new Color(0.42f, 0.32f, 0.28f);
                characterTarget.stubbleColor = new Color(0.39f, 0.29f, 0.25f);
            }
            else if (skinColorRange == 2)
            {
                characterTarget.skinColor = new Color(0.33f, 0.25f, 0.2f);
                characterTarget.scarColor = new Color(0.42f, 0.32f, 0.28f);
                characterTarget.stubbleColor = new Color(0.21f, 0.17f, 0.16f);
            }
            else
            {
                characterTarget.skinColor = new Color(0.96f, 0.78f, 0.73f);
                characterTarget.scarColor = new Color(0.87f, 0.66f, 0.63f);
                characterTarget.stubbleColor = new Color(0.86f, 0.73f, 0.69f);
            }

            #endregion

            #region hair color

            int hairColorRange = Random.Range(1, 10);
            if (hairColorRange == 10)
            {
                characterTarget.hairColor = new Color(0.31f, 0.25f, 0.18f);
            } 
            else if (hairColorRange == 9)
            {
                characterTarget.hairColor = new Color(0.22f, 0.22f, 0.22f);
            }
            else if (hairColorRange == 8)
            {
                characterTarget.hairColor = new Color(0.83f, 0.62f, 0.36f);
            }
            else if (hairColorRange == 7)
            {
                characterTarget.hairColor = new Color(0.89f, 0.78f, 0.55f);
            }
            else if (hairColorRange == 6)
            {
                characterTarget.hairColor = new Color(0.8f, 0.82f, 0.81f);
            }
            else if (hairColorRange == 5)
            {
                characterTarget.hairColor = new Color(0.69f, 0.4f, 0.24f);
            }
            else if (hairColorRange == 4)
            {
                characterTarget.hairColor = new Color(0.55f, 0.43f, 0.22f);
            }
            else if (hairColorRange == 4)
            {
                characterTarget.hairColor = new Color(0.85f, 0.47f, 0.25f);
            }
            else if (hairColorRange == 2)
            {
                characterTarget.hairColor = new Color(0.38f, 0.24f, 0.05f);
            }
            else
            {
                characterTarget.hairColor = new Color(0.6f, 0.21f, 0.1f);
            }

            #endregion
            
            #region body art color

            int bodyArtColor = Random.Range(1, 8);
            if (bodyArtColor == 8)
            {
                characterTarget.bodyArtColor = new Color(0.05f, 0.67f, 0.98f);
            } else if (bodyArtColor == 7)
            {
                characterTarget.bodyArtColor = new Color(0.72f, 0.27f, 0.27f);
            }
            else if (bodyArtColor == 6)
            {
                characterTarget.bodyArtColor = new Color(0.31f, 0.72f, 0.69f);
            }
            else if (bodyArtColor == 5)
            {
                characterTarget.bodyArtColor = new Color(0.93f, 0.88f, 0.85f);
            }
            else if (bodyArtColor == 4)
            {
                characterTarget.bodyArtColor = new Color(0.31f, 0.71f, 0.31f);
            }
            else if (bodyArtColor == 3)
            {
                characterTarget.bodyArtColor = new Color(0.53f, 0.31f, 0.65f);
            }
            else if (bodyArtColor == 2)
            {
                characterTarget.bodyArtColor = new Color(0.87f, 0.78f, 0.25f);
            }
            else
            {
                characterTarget.bodyArtColor = new Color(0.24f, 0.46f, 0.82f);
            }

            #endregion
            
            characterTarget.UpdateCharacterVisuals();

            return true;
        }
        
        // +--------------------------------------------------------------------------------------+
        // | EDITOR                                                                               |
        // +--------------------------------------------------------------------------------------+
        
        #if UNITY_EDITOR
        
        public static new string NAME = "Synty Character/Randomize Character";
        private const string NODE_TITLE = "Randomize Character";
        
        // PROPERTIES: ----------------------------------------------------------------------------
        
        private SerializedProperty spCharacter;
        
        // INSPECTOR METHODS: ---------------------------------------------------------------------
        
        public override string GetNodeTitle()
        {
            return NODE_TITLE;
        }
        
        protected override void OnEnableEditorChild ()
        {
            this.spCharacter = this.serializedObject.FindProperty("character");
        }
        
        protected override void OnDisableEditorChild ()
        {
            this.spCharacter = null;
        }
        
        public override void OnInspectorGUI()
        {
            this.serializedObject.Update();

            EditorGUILayout.PropertyField(this.spCharacter);
            
            this.serializedObject.ApplyModifiedProperties();
        }
        
        #endif
    }
}