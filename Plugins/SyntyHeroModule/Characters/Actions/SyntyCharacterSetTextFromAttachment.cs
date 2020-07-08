using GameCreator.Characters;
using GameCreator.Core;

namespace Synty.GameCreator.Characters
{
    using TMPro;
    using UnityEngine;
    
    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    
    [AddComponentMenu("")]
    public class SyntyCharacterSetTextFromAttachmentId : IAction
    {
        public enum Element
        {
            HeadAllElements,
            HeadNoElements,
            Eyebrow,
            FacialHair,
            Torso,
            ArmUpperRight,
            ArmUpperLeft,
            ArmLowerRight,
            ArmLowerLeft,
            HandRight,
            HandLeft,
            Hips,
            LegRight,
            LegLeft,
            HeadCoveringsBaseHair,
            HeadCoveringsNoFacialHair,
            HeadCoveringsNoHair,
            Hair,
            Helmet,
            BackAttachment,
            ShoulderAttachmentRight,
            ShoulderAttachmentLeft,
            ElbowAttachmentRight,
            ElbowAttachmentLeft,
            HipsAttachment,
            KneeAttachmentRight,
            KneeAttachmentLeft,
            ElfEar
        }
        
        public TextMeshProUGUI text;
        public string content = "{0}";
        public Element element;
        public TargetSyntyCharacter character = new TargetSyntyCharacter();
        
        // EXECUTABLE: ----------------------------------------------------------------------------

        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
            SyntyCharacter characterTarget = this.character.GetCharacter(target);
            if (characterTarget == null) return true;

            if (this.text == null) return true;

            string variable;
            
            switch (element)
            {
                    case Element.HeadAllElements:
                        variable = characterTarget.headAllElementsIndex.ToString();
                        break;
                    case Element.HeadNoElements:
                        variable = characterTarget.headNoElementsIndex.ToString();
                        break;
                    case Element.Eyebrow:
                        variable = characterTarget.eyebrowIndex.ToString();
                        break;
                    case Element.FacialHair:
                        variable = characterTarget.facialHairIndex.ToString();
                        break;
                    case Element.Torso:
                        variable = characterTarget.torsoIndex.ToString();
                        break;
                    case Element.ArmUpperRight:
                        variable = characterTarget.armUpperRightIndex.ToString();
                        break;
                    case Element.ArmUpperLeft:
                        variable = characterTarget.armUpperLeftIndex.ToString();
                        break;
                    case Element.ArmLowerRight:
                        variable = characterTarget.armLowerRightIndex.ToString();
                        break;
                    case Element.ArmLowerLeft:
                        variable = characterTarget.armLowerLeftIndex.ToString();
                        break;
                    case Element.HandRight:
                        variable = characterTarget.handRightIndex.ToString();
                        break;
                    case Element.HandLeft:
                        variable = characterTarget.handLeftIndex.ToString();
                        break;
                    case Element.Hips:
                        variable = characterTarget.hipsIndex.ToString();
                        break;
                    case Element.LegRight:
                        variable = characterTarget.legRightIndex.ToString();
                        break;
                    case Element.LegLeft:
                        variable = characterTarget.legLeftIndex.ToString();
                        break;
                    case Element.HeadCoveringsBaseHair:
                        variable = characterTarget.headCoveringsBaseHairIndex.ToString();
                        break;
                    case Element.HeadCoveringsNoFacialHair:
                        variable = characterTarget.headCoveringsNoFacialHairIndex.ToString();
                        break;
                    case Element.HeadCoveringsNoHair:
                        variable = characterTarget.headCoveringsNoHairIndex.ToString();
                        break;
                    case Element.Hair:
                        variable = characterTarget.hairIndex.ToString();
                        break;
                    case Element.Helmet:
                        variable = characterTarget.helmetIndex.ToString();
                        break;
                    case Element.BackAttachment:
                        variable = characterTarget.backAttackmentIndex.ToString();
                        break;
                    case Element.ShoulderAttachmentRight:
                        variable = characterTarget.shoulderAttachmentRightIndex.ToString();
                        break;
                    case Element.ShoulderAttachmentLeft:
                        variable = characterTarget.shoudlerAttachmentLeftIndex.ToString();
                        break;
                    case Element.ElbowAttachmentRight:
                        variable = characterTarget.elbowAttachmendRightIndex.ToString();
                        break;
                    case Element.ElbowAttachmentLeft:
                        variable = characterTarget.elbowAttachmentLeftIndex.ToString();
                        break;
                    case Element.HipsAttachment:
                        variable = characterTarget.hipsAttachmentIndex.ToString();
                        break;
                    case Element.KneeAttachmentRight:
                        variable = characterTarget.kneeAttachmentRightIndex.ToString();
                        break;
                    case Element.KneeAttachmentLeft:
                        variable = characterTarget.kneeAttachmentLeftIndex.ToString();
                        break;
                    case Element.ElfEar:
                        variable = characterTarget.elfEarIndex.ToString();
                        break;
                    default:
                        variable = "";
                        break;
            }
            
            this.text.SetText(string.Format(
                this.content,
                new string[] { variable }
            ));

            return true;
        }
        
        // +--------------------------------------------------------------------------------------+
        // | EDITOR                                                                               |
        // +--------------------------------------------------------------------------------------+
        
        #if UNITY_EDITOR

        public static new string NAME = "Synty Character/Change Text from Attachment ID";
        private const string NODE_TITLE = "Change text to index of {0}";
        
        // PROPERTIES: ----------------------------------------------------------------------------

        private SerializedProperty spText;
        private SerializedProperty spContent;
        private SerializedProperty spElement;
        private SerializedProperty spCharacter;

        // INSPECTOR METHODS: ---------------------------------------------------------------------
        
        public override string GetNodeTitle()
        {
            return string.Format(NODE_TITLE, this.element.ToString());
        }
        
        protected override void OnEnableEditorChild ()
        {
            this.spText = this.serializedObject.FindProperty("text");
            this.spContent = this.serializedObject.FindProperty("content");
            this.spElement = this.serializedObject.FindProperty("element");
            this.spCharacter = this.serializedObject.FindProperty("character");
        }
        
        protected override void OnDisableEditorChild ()
        {
            this.spText = null;
            this.spContent = null;
            this.spElement = null;
            this.spCharacter = null;
        }
        
        public override void OnInspectorGUI()
        {
            this.serializedObject.Update();

            EditorGUILayout.PropertyField(this.spText);
            EditorGUILayout.PropertyField(this.spElement);
            EditorGUILayout.PropertyField(this.spCharacter);
            EditorGUILayout.PropertyField(this.spContent);

            this.serializedObject.ApplyModifiedProperties();
        }
        
        #endif
    }
}