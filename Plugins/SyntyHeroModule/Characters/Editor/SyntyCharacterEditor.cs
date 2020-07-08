using System.IO;
using GameCreator.Core;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.Events;

namespace GameCreator.Characters
{
    using UnityEditor;
    
    [CustomEditor(typeof(SyntyCharacter), true)]
    public class SyntyCharacterEditor : Editor
    {
        private class Section
        {
            private const string KEY_STATE = "character-section-{0}";

            private readonly GUIContent name;
            public readonly AnimBool state;
            
            public Section(string name, Texture icon, UnityAction repaint)
            {
                this.name = new GUIContent($" {name}", icon);
                this.state = new AnimBool(this.GetState());
                this.state.valueChanged.AddListener(repaint);
            }
            
            public void PaintSection()
            {
                GUIStyle buttonStyle = (this.state.target
                        ? CoreGUIStyles.GetToggleButtonNormalOn()
                        : CoreGUIStyles.GetToggleButtonNormalOff()
                    );

                if (GUILayout.Button(this.name, buttonStyle))
                {
                    this.state.target = !this.state.target;
                    string key = string.Format(KEY_STATE, this.name.text.GetHashCode());
                    EditorPrefs.SetBool(key, this.state.target);
                }
            }
            
            private bool GetState()
            {
                string key = string.Format(KEY_STATE, this.name.text.GetHashCode());
                return EditorPrefs.GetBool(key, true);
            }
        }
        
        // CONSTANTS: --------------------------------------------------------------------------------------------------

        #region Constants

        private const string CHARACTER_ICONS_PATH = "Assets/Plugins/GameCreator/Characters/Icons/";
        
        private const string SECTION_CHAR_PARAMS1 = "Character";
        private const string SECTION_CHAR_PARAMS2 = "Equipment";
        private const string SECTION_CHAR_PARAMS3 = "Parent Transforms";
        
        private const string PROP_GENDER = "gender";
        
        private const string PROP_HEAD_INDEX = "headAllElementsIndex";
        private const string PROP_HEAD_NO_INDEX = "headNoElementsIndex";
        private const string PROP_EYEBROW_INDEX = "eyebrowIndex";
        private const string PROP_FACIAL_HAIR_INDEX = "facialHairIndex";
        private const string PROP_TORSO_INDEX = "torsoIndex";
        private const string PROP_ARM_UPPER_RIGHT_INDEX = "armUpperRightIndex";
        private const string PROP_ARM_UPPER_LEFT_INDEX = "armUpperLeftIndex";
        private const string PROP_ARM_LOWER_RIGHT_INDEX = "armLowerRightIndex";
        private const string PROP_ARM_LOWER_LEFT_INDEX = "armLowerLeftIndex";
        private const string PROP_HAND_RIGHT_INDEX = "handRightIndex";
        private const string PROP_HAND_LEFT_INDEX = "handLeftIndex";
        private const string PROP_HIPS_INDEX = "hipsIndex";
        private const string PROP_LEG_RIGHT_INDEX = "legRightIndex";
        private const string PROP_LEG_LEFT_INDEX = "legLeftIndex";

        private const string PROP_MALEHEAD_ALL_ELEMENTS = "maleHeadAllElements";
        private const string PROP_MALEHEAD_NO_ELEMENTS = "maleHeadNoElements";
        private const string PROP_MALEEYEBROWS = "maleEyebrows";
        private const string PROP_MALEFACIALHAIR = "maleFacialHair";
        private const string PROP_MALETORSO = "maleTorso";
        private const string PROP_MALEARMUPPERRIGHT = "maleArmUpperRight";
        private const string PROP_MALEARMUPPERLEFT = "maleArmUpperLeft";
        private const string PROP_MALEARMLOWERRIGHT = "maleArmLowerRight";
        private const string PROP_MALEARMLOWERLEFT = "maleArmLowerLeft";
        private const string PROP_MALEHANDRIGHT = "maleHandRight";
        private const string PROP_MALEHANDLEFT = "maleHandLeft";
        private const string PROP_MALEHIPS = "maleHips";
        private const string PROP_MALELEGRIGHT = "maleLegRight";
        private const string PROP_MALELEGLEFT = "maleLegLeft";
        private const string PROP_FEMALEHEAD_ALL_ELEMENTS = "femaleHeadAllElements";
        private const string PROP_FEMALEHEAD_NO_ELEMENTS = "femaleHeadNoElements";
        private const string PROP_FEMALEEYEBROWS = "femaleEyebrows";
        private const string PROP_FEMALEFACIALHAIR = "femaleFacialHair";
        private const string PROP_FEMALETORSO = "femaleTorso";
        private const string PROP_FEMALEARMUPPERRIGHT = "femaleArmUpperRight";
        private const string PROP_FEMALEARMUPPERLEFT = "femaleArmUpperLeft";
        private const string PROP_FEMALEARMLOWERRIGHT = "femaleArmLowerRight";
        private const string PROP_FEMALEARMLOWERLEFT = "femaleArmLowerLeft";
        private const string PROP_FEMALEHANDRIGHT = "femaleHandRight";
        private const string PROP_FEMALEHANDLEFT = "femaleHandLeft";
        private const string PROP_FEMALEHIPS = "femaleHips";
        private const string PROP_FEMALELEGRIGHT = "femaleLegRight";
        private const string PROP_FEMALELEGLEFT = "femaleLegLeft";

        private const string PROP_HEADCOVERINGSBASEHAIRINDEX = "headCoveringsBaseHairIndex";
        private const string PROP_HEADCOVERINGSNOFACIALHAIRINDEX = "headCoveringsNoFacialHairIndex";
        private const string PROP_HEADCOVERINGSNOHAIRINDEX = "headCoveringsNoHairIndex";
        private const string PROP_HAIRINDEX = "hairIndex";
        private const string PROP_HELMETINDEX = "helmetIndex";
        private const string PROP_BACKATTACKMENTINDEX = "backAttackmentIndex";
        private const string PROP_SHOULDERATTACHMENTRIGHTINDEX = "shoulderAttachmentRightIndex";
        private const string PROP_SHOUDLERATTACHMENTLEFTINDEX = "shoudlerAttachmentLeftIndex";
        private const string PROP_ELBOWATTACHMENDRIGHTINDEX = "elbowAttachmendRightIndex";
        private const string PROP_ELBOWATTACHMENTLEFTINDEX = "elbowAttachmentLeftIndex";
        private const string PROP_HIPSATTACHMENTINDEX = "hipsAttachmentIndex";
        private const string PROP_KNEEATTACHMENTRIGHTINDEX = "kneeAttachmentRightIndex";
        private const string PROP_KNEEATTACHMENTLEFTINDEX = "kneeAttachmentLeftIndex";
        private const string PROP_ELF_EAR_INDEX = "elfEarIndex";
        
        private const string PROP_HEADCOVERINGSBASEHAIR = "headCoveringsBaseHair";
        private const string PROP_HEADCOVERINGSNOFACIALHAIR = "headCoveringsNoFacialHair";
        private const string PROP_HEADCOVERINGSNOHAIR = "headCoveringsNoHair";
        private const string PROP_HAIR = "hair";
        private const string PROP_HELMET = "helmet";
        private const string PROP_BACKATTACKMENT = "backAttackment";
        private const string PROP_SHOULDERATTACHMENTRIGHT = "shoulderAttachmentRight";
        private const string PROP_SHOULDERATTACHMENTLEFT = "shoulderAttachmentLeft";
        private const string PROP_ELBOWATTACHMENDRIGHT = "elbowAttachmendRight";
        private const string PROP_ELBOWATTACHMENTLEFT = "elbowAttachmentLeft";
        private const string PROP_HIPSATTACHMENT = "hipsAttachment";
        private const string PROP_KNEEATTACHMENTRIGHT = "kneeAttachmentRight";
        private const string PROP_KNEEATTACHMENTLEFT = "kneeAttachmentLeft";
        private const string PROP_ELF_EAR = "elfEar";
        
        private const string PROP_PRIMARYCOLOR = "primaryColor";
        private const string PROP_SECONDARYCOLOR = "secondaryColor";
        private const string PROP_LEATHERPRIMARYCOLOR = "leatherPrimaryColor";
        private const string PROP_LEATHERSECONDARYCOLOR = "leatherSecondaryColor";
        private const string PROP_METALPRIMARYCOLOR = "metalPrimaryColor";
        private const string PROP_METALSECONDARYCOLOR = "metalSecondaryColor";
        private const string PROP_METALDARKCOLOR = "metalDarkColor";
        private const string PROP_HAIRCOLOR = "hairColor";
        private const string PROP_SKINCOLOR = "skinColor";
        private const string PROP_STUBBLECOLOR = "stubbleColor";
        private const string PROP_SCARCOLOR = "scarColor";
        private const string PROP_BODYARTCOLOR = "bodyArtColor";
        private const string PROP_EYECOLOR = "eyeColor";

        private const string PROP_SAVEOB = "save";

        #endregion
        
        // PROPERTIES: -------------------------------------------------------------------------------------------------

        #region Properties

        private SyntyCharacter character;
        private Section sectionProperties1;
        private Section sectionProperties2;
        private Section sectionProperties3;
        
        private bool isDraggingModel;
        
        private SerializedProperty spGender;
        
        private SerializedProperty spHeadAllIndex;
        private SerializedProperty spHeadNoIndex;
        private SerializedProperty spEyebrowIndex;
        private SerializedProperty spFacialHairIndex;
        private SerializedProperty spTorsoIndex;
        private SerializedProperty spArmUpperRightIndex;
        private SerializedProperty spArmUpperLeftIndex;
        private SerializedProperty spArmLowerRightIndex;
        private SerializedProperty spArmLowerLeftIndex;
        private SerializedProperty spHandRightIndex;
        private SerializedProperty spHandLeftIndex;
        private SerializedProperty spHipsIndex;
        private SerializedProperty spLegRightIndex;
        private SerializedProperty spLegLeftIndex;

        private SerializedProperty spMaleHeadAllElements;
        private SerializedProperty spMaleHeadNoElements;
        private SerializedProperty spMaleEyebrows;
        private SerializedProperty spMaleFacialHair;
        private SerializedProperty spMaleTorso;
        private SerializedProperty spMaleArmUpperRight;
        private SerializedProperty spMaleArmUpperLeft;
        private SerializedProperty spMaleArmLowerRight;
        private SerializedProperty spMaleArmLowerLeft;
        private SerializedProperty spMaleHandRight;
        private SerializedProperty spMaleHandLeft;
        private SerializedProperty spMaleHips;
        private SerializedProperty spMaleLegRight;
        private SerializedProperty spMaleLegLeft;
        private SerializedProperty spFemaleHeadAllElements;
        private SerializedProperty spFemaleHeadNoElements;
        private SerializedProperty spFemaleEyebrows;
        private SerializedProperty spFemaleFacialHair;
        private SerializedProperty spFemaleTorso;
        private SerializedProperty spFemaleArmUpperRight;
        private SerializedProperty spFemaleArmUpperLeft;
        private SerializedProperty spFemaleArmLowerRight;
        private SerializedProperty spFemaleArmLowerLeft;
        private SerializedProperty spFemaleHandRight;
        private SerializedProperty spFemaleHandLeft;
        private SerializedProperty spFemaleHips;
        private SerializedProperty spFemaleLegRight;
        private SerializedProperty spFemaleLegLeft;
        
        private SerializedProperty spHeadCoveringsBaseHairIndex;
        private SerializedProperty spHeadCoveringsNoFacialHairIndex;
        private SerializedProperty spHeadCoveringsNoHairIndex;
        private SerializedProperty spHairIndex;
        private SerializedProperty spHelmetIndex;
        private SerializedProperty spBackAttackmentIndex;
        private SerializedProperty spShoulderAttachmentRightIndex;
        private SerializedProperty spShoudlerAttachmentLeftIndex;
        private SerializedProperty spElbowAttachmendRightIndex;
        private SerializedProperty spElbowAttachmentLeftIndex;
        private SerializedProperty spHipsAttachmentIndex;
        private SerializedProperty spKneeAttachmentRightIndex;
        private SerializedProperty spKneeAttachmentLeftIndex;
        private SerializedProperty spElfEarIndex;

        private SerializedProperty spHeadCoveringsBaseHair;
        private SerializedProperty spHeadCoveringsNoFacialHair;
        private SerializedProperty spHeadCoveringsNoHair;
        private SerializedProperty spHair;
        private SerializedProperty spHelmet;
        private SerializedProperty spBackAttackment;
        private SerializedProperty spShoulderAttachmentRight;
        private SerializedProperty spShoulderAttachmentLeft;
        private SerializedProperty spElbowAttachmendRight;
        private SerializedProperty spElbowAttachmentLeft;
        private SerializedProperty spHipsAttachment;
        private SerializedProperty spKneeAttachmentRight;
        private SerializedProperty spKneeAttachmentLeft;
        private SerializedProperty spElfEar;
        
        private SerializedProperty spPrimaryColor;
        private SerializedProperty spSecondaryColor;
        private SerializedProperty spLeatherPrimaryColor;
        private SerializedProperty spLeatherSecondaryColor;
        private SerializedProperty spMetalPrimaryColor;
        private SerializedProperty spMetalSecondaryColor;
        private SerializedProperty spMetalDarkColor;
        private SerializedProperty spHairColor;
        private SerializedProperty spSkinColor;
        private SerializedProperty spStubbleColor;
        private SerializedProperty spScarColor;
        private SerializedProperty spBodyArtColor;
        private SerializedProperty spEyeColor;

        private SerializedProperty spSave;

        #endregion
        
        // INITIALIZER: -----------------------------------------------------------------------------------------------

        protected void OnEnable()
        {
            this.character = (SyntyCharacter)target;

            string iconProperties1Path = Path.Combine(CHARACTER_ICONS_PATH, "CharacterAnimModel.png");
            Texture2D iconProperties1 = AssetDatabase.LoadAssetAtPath<Texture2D>(iconProperties1Path);
            this.sectionProperties1 = new Section(SECTION_CHAR_PARAMS1, iconProperties1, this.Repaint);
            
            string iconProperties2Path = Path.Combine(CHARACTER_ICONS_PATH, "CharacterAnimRagdoll.png");
            Texture2D iconProperties2 = AssetDatabase.LoadAssetAtPath<Texture2D>(iconProperties2Path);
            this.sectionProperties2 = new Section(SECTION_CHAR_PARAMS2, iconProperties2, this.Repaint);
            
            string iconProperties3Path = Path.Combine(CHARACTER_ICONS_PATH, "CharacterBasicParameters.png");
            Texture2D iconProperties3 = AssetDatabase.LoadAssetAtPath<Texture2D>(iconProperties3Path);
            this.sectionProperties3 = new Section(SECTION_CHAR_PARAMS3, iconProperties3, this.Repaint);

            this.spGender = serializedObject.FindProperty(PROP_GENDER);
            
            this.spHeadAllIndex = serializedObject.FindProperty(PROP_HEAD_INDEX);
            this.spHeadNoIndex = serializedObject.FindProperty(PROP_HEAD_NO_INDEX);
            this.spEyebrowIndex = serializedObject.FindProperty(PROP_EYEBROW_INDEX);
            this.spFacialHairIndex = serializedObject.FindProperty(PROP_FACIAL_HAIR_INDEX);
            this.spTorsoIndex = serializedObject.FindProperty(PROP_TORSO_INDEX);
            this.spArmUpperRightIndex = serializedObject.FindProperty(PROP_ARM_UPPER_RIGHT_INDEX);
            this.spArmUpperLeftIndex = serializedObject.FindProperty(PROP_ARM_UPPER_LEFT_INDEX);
            this.spArmLowerRightIndex = serializedObject.FindProperty(PROP_ARM_LOWER_RIGHT_INDEX);
            this.spArmLowerLeftIndex = serializedObject.FindProperty(PROP_ARM_LOWER_LEFT_INDEX);
            this.spHandRightIndex = serializedObject.FindProperty(PROP_HAND_RIGHT_INDEX);
            this.spHandLeftIndex = serializedObject.FindProperty(PROP_HAND_LEFT_INDEX);
            this.spHipsIndex = serializedObject.FindProperty(PROP_HIPS_INDEX);
            this.spLegRightIndex = serializedObject.FindProperty(PROP_LEG_RIGHT_INDEX);
            this.spLegLeftIndex = serializedObject.FindProperty(PROP_LEG_LEFT_INDEX);

            this.spSave = serializedObject.FindProperty(PROP_SAVEOB);

            this.spMaleHeadAllElements = serializedObject.FindProperty(PROP_MALEHEAD_ALL_ELEMENTS);
            this.spMaleHeadNoElements = serializedObject.FindProperty(PROP_MALEHEAD_NO_ELEMENTS);
            this.spMaleEyebrows = serializedObject.FindProperty(PROP_MALEEYEBROWS);
            this.spMaleFacialHair = serializedObject.FindProperty(PROP_MALEFACIALHAIR);
            this.spMaleTorso = serializedObject.FindProperty(PROP_MALETORSO);
            this.spMaleArmUpperRight = serializedObject.FindProperty(PROP_MALEARMUPPERRIGHT);
            this.spMaleArmUpperLeft = serializedObject.FindProperty(PROP_MALEARMUPPERLEFT);
            this.spMaleArmLowerRight = serializedObject.FindProperty(PROP_MALEARMLOWERRIGHT);
            this.spMaleArmLowerLeft = serializedObject.FindProperty(PROP_MALEARMLOWERLEFT);
            this.spMaleHandRight = serializedObject.FindProperty(PROP_MALEHANDRIGHT);
            this.spMaleHandLeft = serializedObject.FindProperty(PROP_MALEHANDLEFT);
            this.spMaleHips = serializedObject.FindProperty(PROP_MALEHIPS);
            this.spMaleLegRight = serializedObject.FindProperty(PROP_MALELEGRIGHT);
            this.spMaleLegLeft = serializedObject.FindProperty(PROP_MALELEGLEFT);
            this.spFemaleHeadAllElements = serializedObject.FindProperty(PROP_FEMALEHEAD_ALL_ELEMENTS);
            this.spFemaleHeadNoElements = serializedObject.FindProperty(PROP_FEMALEHEAD_NO_ELEMENTS);
            this.spFemaleEyebrows = serializedObject.FindProperty(PROP_FEMALEEYEBROWS);
            this.spFemaleFacialHair = serializedObject.FindProperty(PROP_FEMALEFACIALHAIR);
            this.spFemaleTorso = serializedObject.FindProperty(PROP_FEMALETORSO);
            this.spFemaleArmUpperRight = serializedObject.FindProperty(PROP_FEMALEARMUPPERRIGHT);
            this.spFemaleArmUpperLeft = serializedObject.FindProperty(PROP_FEMALEARMUPPERLEFT);
            this.spFemaleArmLowerRight = serializedObject.FindProperty(PROP_FEMALEARMLOWERRIGHT);
            this.spFemaleArmLowerLeft = serializedObject.FindProperty(PROP_FEMALEARMLOWERLEFT);
            this.spFemaleHandRight = serializedObject.FindProperty(PROP_FEMALEHANDRIGHT);
            this.spFemaleHandLeft = serializedObject.FindProperty(PROP_FEMALEHANDLEFT);
            this.spFemaleHips = serializedObject.FindProperty(PROP_FEMALEHIPS);
            this.spFemaleLegRight = serializedObject.FindProperty(PROP_FEMALELEGRIGHT);
            this.spFemaleLegLeft = serializedObject.FindProperty(PROP_FEMALELEGLEFT);
            
            this.spHeadCoveringsBaseHairIndex = serializedObject.FindProperty(PROP_HEADCOVERINGSBASEHAIRINDEX);
            this.spHeadCoveringsNoFacialHairIndex = serializedObject.FindProperty(PROP_HEADCOVERINGSNOFACIALHAIRINDEX);
            this.spHeadCoveringsNoHairIndex = serializedObject.FindProperty(PROP_HEADCOVERINGSNOHAIRINDEX);
            this.spHairIndex = serializedObject.FindProperty(PROP_HAIRINDEX);
            this.spHelmetIndex = serializedObject.FindProperty(PROP_HELMETINDEX);
            this.spBackAttackmentIndex = serializedObject.FindProperty(PROP_BACKATTACKMENTINDEX);
            this.spShoulderAttachmentRightIndex = serializedObject.FindProperty(PROP_SHOULDERATTACHMENTRIGHTINDEX);
            this.spShoudlerAttachmentLeftIndex = serializedObject.FindProperty(PROP_SHOUDLERATTACHMENTLEFTINDEX);
            this.spElbowAttachmendRightIndex = serializedObject.FindProperty(PROP_ELBOWATTACHMENDRIGHTINDEX);
            this.spElbowAttachmentLeftIndex = serializedObject.FindProperty(PROP_ELBOWATTACHMENTLEFTINDEX);
            this.spHipsAttachmentIndex = serializedObject.FindProperty(PROP_HIPSATTACHMENTINDEX);
            this.spKneeAttachmentRightIndex = serializedObject.FindProperty(PROP_KNEEATTACHMENTRIGHTINDEX);
            this.spKneeAttachmentLeftIndex = serializedObject.FindProperty(PROP_KNEEATTACHMENTLEFTINDEX);
            this.spElfEarIndex = serializedObject.FindProperty(PROP_ELF_EAR_INDEX);

            this.spHeadCoveringsBaseHair = serializedObject.FindProperty(PROP_HEADCOVERINGSBASEHAIR);
            this.spHeadCoveringsNoFacialHair = serializedObject.FindProperty(PROP_HEADCOVERINGSNOFACIALHAIR);
            this.spHeadCoveringsNoHair = serializedObject.FindProperty(PROP_HEADCOVERINGSNOHAIR);
            this.spHair = serializedObject.FindProperty(PROP_HAIR);
            this.spHelmet = serializedObject.FindProperty(PROP_HELMET);
            this.spBackAttackment = serializedObject.FindProperty(PROP_BACKATTACKMENT);
            this.spShoulderAttachmentRight = serializedObject.FindProperty(PROP_SHOULDERATTACHMENTRIGHT);
            this.spShoulderAttachmentLeft = serializedObject.FindProperty(PROP_SHOULDERATTACHMENTLEFT);
            this.spElbowAttachmendRight = serializedObject.FindProperty(PROP_ELBOWATTACHMENDRIGHT);
            this.spElbowAttachmentLeft = serializedObject.FindProperty(PROP_ELBOWATTACHMENTLEFT);
            this.spHipsAttachment = serializedObject.FindProperty(PROP_HIPSATTACHMENT);
            this.spKneeAttachmentRight = serializedObject.FindProperty(PROP_KNEEATTACHMENTRIGHT);
            this.spKneeAttachmentLeft = serializedObject.FindProperty(PROP_KNEEATTACHMENTLEFT);
            this.spElfEar = serializedObject.FindProperty(PROP_ELF_EAR);
            
            this.spPrimaryColor = serializedObject.FindProperty(PROP_PRIMARYCOLOR);
            this.spSecondaryColor = serializedObject.FindProperty(PROP_SECONDARYCOLOR);
            this.spLeatherPrimaryColor = serializedObject.FindProperty(PROP_LEATHERPRIMARYCOLOR);
            this.spLeatherSecondaryColor = serializedObject.FindProperty(PROP_LEATHERSECONDARYCOLOR);
            this.spMetalPrimaryColor = serializedObject.FindProperty(PROP_METALPRIMARYCOLOR);
            this.spMetalSecondaryColor = serializedObject.FindProperty(PROP_METALSECONDARYCOLOR);
            this.spMetalDarkColor = serializedObject.FindProperty(PROP_METALDARKCOLOR);
            this.spHairColor = serializedObject.FindProperty(PROP_HAIRCOLOR);
            this.spSkinColor = serializedObject.FindProperty(PROP_SKINCOLOR);
            this.spStubbleColor = serializedObject.FindProperty(PROP_STUBBLECOLOR);
            this.spScarColor = serializedObject.FindProperty(PROP_SCARCOLOR);
            this.spBodyArtColor = serializedObject.FindProperty(PROP_BODYARTCOLOR);
            this.spEyeColor = serializedObject.FindProperty(PROP_EYECOLOR);

            this.spSave = serializedObject.FindProperty(PROP_SAVEOB);

        }
        
        protected void OnDisable()
        {
            this.character = null;
        }
        
        // INSPECTOR GUI: ----------------------------------------------------------------------------------------------

        public override void OnInspectorGUI ()
        {
            serializedObject.Update();
            EditorGUILayout.Space();

            this.PaintInspector();

            EditorGUILayout.Space();
            GlobalEditorID.Paint(this.character);

            EditorGUILayout.Space();
            serializedObject.ApplyModifiedProperties();
        }

        private void PaintInspector()
        {
            this.PaintCharacterBasicProperties();
            this.PaintChangeModel();
        }

        private void PaintCharacterBasicProperties()
        {
            this.sectionProperties1.PaintSection();
            using (var group = new EditorGUILayout.FadeGroupScope(this.sectionProperties1.state.faded))
            {
                if (group.visible)
                {
                    EditorGUILayout.BeginVertical(CoreGUIStyles.GetBoxExpanded());

                    EditorGUILayout.LabelField("Basics:", EditorStyles.boldLabel);
                    EditorGUI.indentLevel++;
                    EditorGUILayout.LabelField("Save/Load:", EditorStyles.boldLabel);
                    EditorGUILayout.PropertyField(this.spSave);
                    EditorGUI.indentLevel--;
                    
                    EditorGUILayout.Space();
                    
                    EditorGUILayout.LabelField("Character Visuals:", EditorStyles.boldLabel);
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PropertyField(this.spGender);
                    EditorGUILayout.PropertyField(this.spHeadAllIndex);
                    EditorGUILayout.PropertyField(this.spHeadNoIndex);
                    EditorGUILayout.PropertyField(this.spEyebrowIndex);
                    EditorGUILayout.PropertyField(this.spFacialHairIndex);
                    EditorGUI.indentLevel--;
                    
                    EditorGUILayout.LabelField("Character Colors:", EditorStyles.boldLabel);
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PropertyField(this.spPrimaryColor);
                    EditorGUILayout.PropertyField(this.spSecondaryColor);
                    EditorGUILayout.PropertyField(this.spLeatherPrimaryColor);
                    EditorGUILayout.PropertyField(this.spLeatherSecondaryColor);
                    EditorGUILayout.PropertyField(this.spMetalPrimaryColor);
                    EditorGUILayout.PropertyField(this.spMetalSecondaryColor);
                    EditorGUILayout.PropertyField(this.spMetalDarkColor);
                    EditorGUILayout.PropertyField(this.spHairColor);
                    EditorGUILayout.PropertyField(this.spSkinColor);
                    EditorGUILayout.PropertyField(this.spStubbleColor);
                    EditorGUILayout.PropertyField(this.spScarColor);
                    EditorGUILayout.PropertyField(this.spBodyArtColor);
                    EditorGUILayout.PropertyField(this.spEyeColor);
                    EditorGUI.indentLevel--;

                    EditorGUILayout.EndVertical();
                }
            }

            this.sectionProperties2.PaintSection();
            using (var group = new EditorGUILayout.FadeGroupScope(this.sectionProperties2.state.faded))
            {
                if (group.visible)
                {
                    EditorGUILayout.BeginVertical(CoreGUIStyles.GetBoxExpanded());

                    EditorGUILayout.LabelField("Equipment Visuals:", EditorStyles.boldLabel);
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PropertyField(this.spTorsoIndex);
                    EditorGUILayout.PropertyField(this.spArmUpperRightIndex);
                    EditorGUILayout.PropertyField(this.spArmUpperLeftIndex);
                    EditorGUILayout.PropertyField(this.spArmLowerRightIndex);
                    EditorGUILayout.PropertyField(this.spArmLowerLeftIndex);
                    EditorGUILayout.PropertyField(this.spHandRightIndex);
                    EditorGUILayout.PropertyField(this.spHandLeftIndex);
                    EditorGUILayout.PropertyField(this.spHipsIndex);
                    EditorGUILayout.PropertyField(this.spLegRightIndex);
                    EditorGUILayout.PropertyField(this.spLegLeftIndex);
                    EditorGUI.indentLevel--;
                    
                    EditorGUILayout.LabelField("Extras:", EditorStyles.boldLabel);
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PropertyField(this.spHeadCoveringsBaseHairIndex);
                    EditorGUILayout.PropertyField(this.spHeadCoveringsNoFacialHairIndex);
                    EditorGUILayout.PropertyField(this.spHeadCoveringsNoHairIndex);
                    EditorGUILayout.PropertyField(this.spHairIndex);
                    EditorGUILayout.PropertyField(this.spHelmetIndex);
                    EditorGUILayout.PropertyField(this.spBackAttackmentIndex);
                    EditorGUILayout.PropertyField(this.spShoulderAttachmentRightIndex);
                    EditorGUILayout.PropertyField(this.spShoudlerAttachmentLeftIndex);
                    EditorGUILayout.PropertyField(this.spElbowAttachmendRightIndex);
                    EditorGUILayout.PropertyField(this.spElbowAttachmentLeftIndex);
                    EditorGUILayout.PropertyField(this.spHipsAttachmentIndex);
                    EditorGUILayout.PropertyField(this.spKneeAttachmentRightIndex);
                    EditorGUILayout.PropertyField(this.spKneeAttachmentLeftIndex);
                    EditorGUILayout.PropertyField(this.spElfEarIndex);
                    EditorGUI.indentLevel--;

                    EditorGUILayout.EndVertical();
                }
            }
            
            this.sectionProperties3.PaintSection();
            using (var group = new EditorGUILayout.FadeGroupScope(this.sectionProperties3.state.faded))
            {
                if (group.visible)
                {
                    EditorGUILayout.BeginVertical(CoreGUIStyles.GetBoxExpanded());

                    EditorGUILayout.HelpBox("Automatically Populated by Drag & Dropping a Prefab in the box below.", MessageType.Info);
                    
                    EditorGUILayout.LabelField("References:", EditorStyles.boldLabel);
                    EditorGUI.indentLevel++;
                    EditorGUILayout.PropertyField(this.spMaleHeadAllElements);
                    EditorGUILayout.PropertyField(this.spMaleHeadNoElements);
                    EditorGUILayout.PropertyField(this.spMaleEyebrows);
                    EditorGUILayout.PropertyField(this.spMaleFacialHair);
                    EditorGUILayout.PropertyField(this.spMaleTorso);
                    EditorGUILayout.PropertyField(this.spMaleArmUpperRight);
                    EditorGUILayout.PropertyField(this.spMaleArmUpperLeft);
                    EditorGUILayout.PropertyField(this.spMaleArmLowerRight);
                    EditorGUILayout.PropertyField(this.spMaleArmLowerLeft);
                    EditorGUILayout.PropertyField(this.spMaleHandRight);
                    EditorGUILayout.PropertyField(this.spMaleHandLeft);
                    EditorGUILayout.PropertyField(this.spMaleHips);
                    EditorGUILayout.PropertyField(this.spMaleLegRight);
                    EditorGUILayout.PropertyField(this.spMaleLegLeft);
                    EditorGUILayout.PropertyField(this.spFemaleHeadAllElements);
                    EditorGUILayout.PropertyField(this.spFemaleHeadNoElements);
                    EditorGUILayout.PropertyField(this.spFemaleEyebrows);
                    EditorGUILayout.PropertyField(this.spFemaleFacialHair);
                    EditorGUILayout.PropertyField(this.spFemaleTorso);
                    EditorGUILayout.PropertyField(this.spFemaleArmUpperRight);
                    EditorGUILayout.PropertyField(this.spFemaleArmUpperLeft);
                    EditorGUILayout.PropertyField(this.spFemaleArmLowerRight);
                    EditorGUILayout.PropertyField(this.spFemaleArmLowerLeft);
                    EditorGUILayout.PropertyField(this.spFemaleHandRight);
                    EditorGUILayout.PropertyField(this.spFemaleHandLeft);
                    EditorGUILayout.PropertyField(this.spFemaleHips);
                    EditorGUILayout.PropertyField(this.spFemaleLegRight);
                    EditorGUILayout.PropertyField(this.spFemaleLegLeft);
                    EditorGUILayout.PropertyField(this.spHeadCoveringsBaseHair);
                    EditorGUILayout.PropertyField(this.spHeadCoveringsNoFacialHair);
                    EditorGUILayout.PropertyField(this.spHeadCoveringsNoHair);
                    EditorGUILayout.PropertyField(this.spHair);
                    EditorGUILayout.PropertyField(this.spHelmet);
                    EditorGUILayout.PropertyField(this.spBackAttackment);
                    EditorGUILayout.PropertyField(this.spShoulderAttachmentRight);
                    EditorGUILayout.PropertyField(this.spShoulderAttachmentLeft);
                    EditorGUILayout.PropertyField(this.spElbowAttachmendRight);
                    EditorGUILayout.PropertyField(this.spElbowAttachmentLeft);
                    EditorGUILayout.PropertyField(this.spHipsAttachment);
                    EditorGUILayout.PropertyField(this.spKneeAttachmentRight);
                    EditorGUILayout.PropertyField(this.spKneeAttachmentLeft);
                    EditorGUILayout.PropertyField(this.spElfEar);
                    EditorGUI.indentLevel--;

                    EditorGUILayout.EndVertical();
                }
            }
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void PaintChangeModel()
        {
            if (GUILayout.Button("Load Character"))
            {
                this.LoadCharacter();
            }
        }

        private void LoadCharacter()
        {
            this.character.LoadCharacterTransforms();
            serializedObject.Update();
        }
    }
}
