using GameCreator.Characters;
using GameCreator.Core;
using Synty.GameCreator.Characters;
using UnityEngine;

namespace Synty.GameCreator.Characters
{
    #if UNITY_EDITOR
        using UnityEditor;
    #endif

    [AddComponentMenu("")]
    public class SyntyCharacterAttachment : IAction
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

        public enum Position
        {
            Index,
            First,
            Last,
            Random,
            Next,
            Previous
        }
        
        public TargetSyntyCharacter character = new TargetSyntyCharacter();
        
        public Element element = Element.Hair;
        
        public Position select = Position.First;
        public int index;

        // EXECUTABLE: ----------------------------------------------------------------------------
        
        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
            SyntyCharacter characterTarget = this.character.GetCharacter(target);
            if (characterTarget == null) return true;

            int newIndex = 0;
            int tmpCurrent = 0;
            int tmpTotal = 0;
            
            switch (this.element)
            {
                case Element.HeadAllElements:
                    tmpTotal = characterTarget.headAllElementsTotal;
                    tmpCurrent = characterTarget.headAllElementsIndex;
                    break;
                case Element.HeadNoElements:
                    tmpTotal = characterTarget.headNoElementsTotal;
                    tmpCurrent = characterTarget.headNoElementsIndex;
                    break;
                case Element.Eyebrow:
                    if(characterTarget.gender == SyntyCharacter.EnumGender.Female)
                        tmpTotal = characterTarget.femaleEyebrows.childCount;
                    else
                        tmpTotal = characterTarget.eyebrowTotal;
                    
                    tmpCurrent = characterTarget.eyebrowIndex;
                    break;
                case Element.FacialHair:
                    tmpTotal = characterTarget.facialHairTotal;
                    tmpCurrent = characterTarget.facialHairIndex;
                    break;
                case Element.Torso:
                    tmpTotal = characterTarget.torsoTotal;
                    tmpCurrent = characterTarget.torsoIndex;
                    break;
                case Element.ArmUpperRight:
                    tmpTotal = characterTarget.armUpperRightTotal;
                    tmpCurrent = characterTarget.armUpperRightIndex;
                    break;
                case Element.ArmUpperLeft:
                    tmpTotal = characterTarget.armUpperLeftTotal;
                    tmpCurrent = characterTarget.armUpperLeftIndex;
                    break;
                case Element.ArmLowerRight:
                    tmpTotal = characterTarget.armLowerRightTotal;
                    tmpCurrent = characterTarget.armLowerRightIndex;
                    break;
                case Element.ArmLowerLeft:
                    tmpTotal = characterTarget.armLowerLeftTotal;
                    tmpCurrent = characterTarget.armLowerLeftIndex;
                    break;
                case Element.HandRight:
                    tmpTotal = characterTarget.handRightTotal;
                    tmpCurrent = characterTarget.handRightIndex;
                    break;
                case Element.HandLeft:
                    tmpTotal = characterTarget.handLeftTotal;
                    tmpCurrent = characterTarget.handLeftIndex;
                    break;
                case Element.Hips:
                    tmpTotal = characterTarget.hipsTotal;
                    tmpCurrent = characterTarget.hipsIndex;
                    break;
                case Element.LegRight:
                    tmpTotal = characterTarget.legRightTotal;
                    tmpCurrent = characterTarget.legRightIndex;
                    break;
                case Element.LegLeft:
                    tmpTotal = characterTarget.legLeftTotal;
                    tmpCurrent = characterTarget.legLeftIndex;
                    break;
                case Element.HeadCoveringsBaseHair:
                    tmpTotal = characterTarget.headCoveringsBaseHairTotal;
                    tmpCurrent = characterTarget.headCoveringsBaseHairIndex;
                    break;
                case Element.HeadCoveringsNoFacialHair:
                    tmpTotal = characterTarget.headCoveringsNoFacialHairTotal;
                    tmpCurrent = characterTarget.headCoveringsNoFacialHairIndex;
                    break;
                case Element.HeadCoveringsNoHair:
                    tmpTotal = characterTarget.headCoveringsNoHairTotal;
                    tmpCurrent = characterTarget.headCoveringsNoHairIndex;
                    break;
                case Element.Hair:
                    tmpTotal = characterTarget.hairTotal;
                    tmpCurrent = characterTarget.hairIndex;
                    break;
                case Element.Helmet:
                    tmpTotal = characterTarget.helmetTotal;
                    tmpCurrent = characterTarget.helmetIndex;
                    break;
                case Element.BackAttachment:
                    tmpTotal = characterTarget.backAttackmentTotal;
                    tmpCurrent = characterTarget.backAttackmentIndex;
                    break;
                case Element.ShoulderAttachmentRight:
                    tmpTotal = characterTarget.shoulderAttachmentRightTotal;
                    tmpCurrent = characterTarget.shoulderAttachmentRightIndex;
                    break;
                case Element.ShoulderAttachmentLeft:
                    tmpTotal = characterTarget.shoudlerAttachmentLeftTotal;
                    tmpCurrent = characterTarget.shoudlerAttachmentLeftIndex;
                    break;
                case Element.ElbowAttachmentRight:
                    tmpTotal = characterTarget.elbowAttachmendRightTotal;
                    tmpCurrent = characterTarget.elbowAttachmendRightIndex;
                    break;
                case Element.ElbowAttachmentLeft:
                    tmpTotal = characterTarget.elbowAttachmentLeftTotal;
                    tmpCurrent = characterTarget.elbowAttachmentLeftIndex;
                    break;
                case Element.HipsAttachment:
                    tmpTotal = characterTarget.hipsAttachmentTotal;
                    tmpCurrent = characterTarget.hipsAttachmentIndex;
                    break;
                case Element.KneeAttachmentRight:
                    tmpTotal = characterTarget.kneeAttachmentRightTotal;
                    tmpCurrent = characterTarget.kneeAttachmentRightIndex;
                    break;
                case Element.KneeAttachmentLeft:
                    tmpTotal = characterTarget.kneeAttachmentLeftTotal;
                    tmpCurrent = characterTarget.kneeAttachmentLeftIndex;
                    break;
                case Element.ElfEar:
                    tmpTotal = characterTarget.elfEarTotal;
                    tmpCurrent = characterTarget.elfEarIndex;
                    break;
            }

            switch (select)
            {
                case Position.First:
                    newIndex = 0;
                    break;
                case Position.Last:
                    newIndex = tmpTotal;
                    break;
                case Position.Random:
                    newIndex = Random.Range(0, tmpTotal - 1);
                    break;
                case Position.Index:
                    newIndex = this.index;
                    break;
                case Position.Next:
                    newIndex = ((tmpCurrent + 1) > (tmpTotal - 1)) ? 0 : tmpCurrent + 1;
                    break;
                case Position.Previous:
                    newIndex = ((tmpCurrent - 1) < 0) ? tmpTotal - 1 : tmpCurrent - 1;
                    break;
            }

            switch (this.element)
            {
                case Element.HeadAllElements:
                    characterTarget.headAllElementsIndex = newIndex;
                    break;
                case Element.HeadNoElements:
                    characterTarget.headNoElementsIndex = newIndex;
                    break;
                case Element.Eyebrow:
                    characterTarget.eyebrowIndex = newIndex;
                    break;
                case Element.FacialHair:
                    characterTarget.facialHairIndex = newIndex;
                    break;
                case Element.Torso:
                    characterTarget.torsoIndex = newIndex;
                    break;
                case Element.ArmUpperRight:
                    characterTarget.armUpperRightIndex = newIndex;
                    break;
                case Element.ArmUpperLeft:
                    characterTarget.armUpperLeftIndex = newIndex;
                    break;
                case Element.ArmLowerRight:
                    characterTarget.armLowerRightIndex = newIndex;
                    break;
                case Element.ArmLowerLeft:
                    characterTarget.armLowerLeftIndex = newIndex;
                    break;
                case Element.HandRight:
                    characterTarget.handRightIndex = newIndex;
                    break;
                case Element.HandLeft:
                    characterTarget.handLeftIndex = newIndex;
                    break;
                case Element.Hips:
                    characterTarget.hipsIndex = newIndex;
                    break;
                case Element.LegRight:
                    characterTarget.legRightIndex = newIndex;
                    break;
                case Element.LegLeft:
                    characterTarget.legLeftIndex = newIndex;
                    break;
                case Element.HeadCoveringsBaseHair:
                    characterTarget.headCoveringsBaseHairIndex = newIndex;
                    break;
                case Element.HeadCoveringsNoFacialHair:
                    characterTarget.headCoveringsNoFacialHairIndex = newIndex;
                    break;
                case Element.HeadCoveringsNoHair:
                    characterTarget.headCoveringsNoHairIndex = newIndex;
                    break;
                case Element.Hair:
                    characterTarget.hairIndex = newIndex;
                    break;
                case Element.Helmet:
                    characterTarget.helmetIndex = newIndex;
                    break;
                case Element.BackAttachment:
                    characterTarget.backAttackmentIndex = newIndex;
                    break;
                case Element.ShoulderAttachmentRight:
                    characterTarget.shoulderAttachmentRightIndex = newIndex;
                    break;
                case Element.ShoulderAttachmentLeft:
                    characterTarget.shoudlerAttachmentLeftIndex = newIndex;
                    break;
                case Element.ElbowAttachmentRight:
                    characterTarget.elbowAttachmendRightIndex = newIndex;
                    break;
                case Element.ElbowAttachmentLeft:
                    characterTarget.elbowAttachmentLeftIndex = newIndex;
                    break;
                case Element.HipsAttachment:
                    characterTarget.hipsAttachmentIndex = newIndex;
                    break;
                case Element.KneeAttachmentRight:
                    characterTarget.kneeAttachmentRightIndex = newIndex;
                    break;
                case Element.KneeAttachmentLeft:
                    characterTarget.kneeAttachmentLeftIndex = newIndex;
                    break;
                case Element.ElfEar:
                    characterTarget.elfEarIndex = newIndex;
                    break;
            }
            
            characterTarget.UpdateCharacterVisuals();

            return true;
        }

        // +--------------------------------------------------------------------------------------+
        // | EDITOR                                                                               |
        // +--------------------------------------------------------------------------------------+
        
        #if UNITY_EDITOR
        
        public static new string NAME = "Synty Character/Synty Character Set Attachment";
        private const string NODE_TITLE = "Set {0} of {1} to {2}";
        
        // PROPERTIES: ----------------------------------------------------------------------------
        
        private SerializedProperty spCharacter;
        
        private SerializedProperty spElement;
        private SerializedProperty spSelect;
        private SerializedProperty spIndex;
        
        // INSPECTOR METHODS: ---------------------------------------------------------------------
        
        public override string GetNodeTitle()
        {
            return string.Format(
                NODE_TITLE, 
                this.element.ToString(),
                this.character,
                (this.@select == Position.Index ? this.index.ToString() : this.@select.ToString())
            );
        }
        
        protected override void OnEnableEditorChild ()
        {
            this.spCharacter = this.serializedObject.FindProperty("character");
            this.spElement = this.serializedObject.FindProperty("element");
            
            this.spSelect = this.serializedObject.FindProperty("select");
            this.spIndex = this.serializedObject.FindProperty("index");
        }
        
        protected override void OnDisableEditorChild ()
        {
            this.spCharacter = null;
            this.spElement = null;

            this.spSelect = null;
            this.spIndex = null;
        }
        
        public override void OnInspectorGUI()
        {
            this.serializedObject.Update();

            EditorGUILayout.PropertyField(this.spCharacter);

            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(this.spElement);
            EditorGUILayout.PropertyField(this.spSelect);
            
            if(this.@select == Position.Index)
                EditorGUILayout.PropertyField(this.spIndex);

            this.serializedObject.ApplyModifiedProperties();
        }
        
        #endif
    }
}


