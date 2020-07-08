using System.Collections.Generic;
using UnityEditor;

namespace GameCreator.Characters
{
    using Core;
    using System;
    using UnityEngine;
    
    [ExecuteInEditMode]
    public class SyntyCharacter : GlobalID, IGameSave
    {
        [Serializable]
        public class SyntyCharacterData
        {
            public EnumGender gender;
            public int headAllElementsIndex;
            public int headNoElementsIndex;
            public int eyebrowIndex;
            public int facialHairIndex;
            public int torsoIndex;
            public int armUpperRightIndex;
            public int armUpperLeftIndex;
            public int armLowerRightIndex;
            public int armLowerLeftIndex;
            public int handRightIndex;
            public int handLeftIndex;
            public int hipsIndex;
            public int legRightIndex;
            public int legLeftIndex;

            public int headCoveringsBaseHairIndex;
            public int headCoveringsNoFacialHairIndex;
            public int headCoveringsNoHairIndex;
            public int hairIndex;
            public int helmetIndex;
            public int backAttackmentIndex;
            public int shoulderAttachmentRightIndex;
            public int shoudlerAttachmentLeftIndex;
            public int elbowAttachmendRightIndex;
            public int elbowAttachmentLeftIndex;
            public int hipsAttachmentIndex;
            public int kneeAttachmentRightIndex;
            public int kneeAttachmentLeftIndex;
            public int elfEarIndex;
            
            public Color primaryColor;
            public Color secondaryColor;
            public Color leatherPrimaryColor;
            public Color leatherSecondaryColor;
            public Color metalPrimaryColor;
            public Color metalSecondaryColor;
            public Color metalDarkColor;
            public Color hairColor;
            public Color skinColor;
            public Color stubbleColor;
            public Color scarColor;
            public Color bodyArtColor;
            public Color eyeColor;
        }
        
        [Serializable]
        public class OnLoadSceneData
        {
            public bool active { get; private set; }
            public EnumGender gender { get; private set; }
            public int headAllElementsIndex { get; private set; }
            public int headNoElementsIndex { get; private set; }
            public int eyebrowIndex { get; private set; }
            public int facialHairIndex { get; private set; }
            public int torsoIndex { get; private set; }
            public int armUpperRightIndex { get; private set; }
            public int armUpperLeftIndex { get; private set; }
            public int armLowerRightIndex { get; private set; }
            public int armLowerLeftIndex { get; private set; }
            public int handRightIndex { get; private set; }
            public int handLeftIndex { get; private set; }
            public int hipsIndex { get; private set; }
            public int legRightIndex { get; private set; }
            public int legLeftIndex { get; private set; }
            
            public Color primaryColor { get; private set;}
            public Color secondaryColor { get; private set;}
            public Color leatherPrimaryColor { get; private set;}
            public Color leatherSecondaryColor { get; private set;}
            public Color metalPrimaryColor { get; private set;}
            public Color metalSecondaryColor { get; private set;}
            public Color metalDarkColor { get; private set;}
            public Color hairColor { get; private set;}
            public Color skinColor { get; private set;}
            public Color stubbleColor { get; private set;}
            public Color scarColor { get; private set;}
            public Color bodyArtColor { get; private set;}
            public Color eyeColor { get; private set;}

            public OnLoadSceneData(EnumGender gender, int headAllElementsIndex, int headNoElementsIndex, int eyebrowIndex, int facialHairIndex, int torsoIndex, int armUpperRightIndex, int armUpperLeftIndex, int armLowerRightIndex, int armLowerLeftIndex, int handRightIndex, int handLeftIndex, int hipsIndex, int legRightIndex, int legLeftIndex, Color primaryColor, Color secondaryColor, Color leatherPrimaryColor, Color leatherSecondaryColor, Color metalPrimaryColor, Color metalSecondaryColor, Color metalDarkColor, Color hairColor, Color skinColor, Color stubbleColor, Color scarColor, Color bodyArtColor, Color eyeColor)
            {
                this.active = true;
                this.gender = gender;
                this.headAllElementsIndex = headAllElementsIndex;
                this.headNoElementsIndex = headNoElementsIndex;
                this.eyebrowIndex = eyebrowIndex;
                this.facialHairIndex = facialHairIndex;
                this.torsoIndex = torsoIndex;
                this.armUpperRightIndex = armUpperRightIndex;
                this.armUpperLeftIndex = armUpperLeftIndex;
                this.armLowerRightIndex = armLowerRightIndex;
                this.armLowerLeftIndex = armLowerLeftIndex;
                this.handRightIndex = handRightIndex;
                this.handLeftIndex = handLeftIndex;
                this.hipsIndex = hipsIndex;
                this.legRightIndex = legRightIndex;
                this.legLeftIndex = legLeftIndex;
                this.primaryColor = primaryColor;
                this.secondaryColor = secondaryColor;
                this.leatherPrimaryColor = leatherPrimaryColor;
                this.leatherSecondaryColor = leatherSecondaryColor;
                this.metalPrimaryColor = metalPrimaryColor;
                this.metalSecondaryColor = metalSecondaryColor;
                this.metalDarkColor = metalDarkColor;
                this.hairColor = hairColor;
                this.skinColor = skinColor;
                this.stubbleColor = stubbleColor;
                this.scarColor = scarColor;
                this.bodyArtColor = bodyArtColor;
                this.eyeColor = eyeColor;
            }

            public void Consume()
            {
                this.active = false;
            }
        }

        [Serializable]
        public enum EnumGender
        {
            Male,
            Female
        }
        
        // PROPERTIES: ----------------------------------------------------------------------------

        #region Properties
        
        public EnumGender gender;

        #region All_00_HeadCoverings

        public Transform headCoveringsBaseHair;
        public int headCoveringsBaseHairIndex;
        public int headCoveringsBaseHairTotal;
        
        public Transform headCoveringsNoFacialHair;
        public int headCoveringsNoFacialHairIndex;
        public int headCoveringsNoFacialHairTotal;
        
        public Transform headCoveringsNoHair;
        public int headCoveringsNoHairIndex;
        public int headCoveringsNoHairTotal;

        #endregion
        
        #region All_01_Hair

        public Transform hair;
        public int hairIndex;
        public int hairTotal;

        #endregion

        #region All_02_Head_Attachment

        public Transform helmet;
        public int helmetIndex;
        public int helmetTotal;

        #endregion

        #region All_04_Back_Attachment

        public Transform backAttackment;
        public int backAttackmentIndex;
        public int backAttackmentTotal;

        #endregion

        #region All_05_Shoulder_Attachment_Right

        public Transform shoulderAttachmentRight;
        public int shoulderAttachmentRightIndex;
        public int shoulderAttachmentRightTotal;

        #endregion
        
        #region All_06_Shoulder_Attachment_Left

        public Transform shoulderAttachmentLeft;
        public int shoudlerAttachmentLeftIndex;
        public int shoudlerAttachmentLeftTotal;

        #endregion

        #region All_07_Elbow_Attachment_Right

        public Transform elbowAttachmendRight;
        public int elbowAttachmendRightIndex;
        public int elbowAttachmendRightTotal;
        
        #endregion
        
        #region All_08_Elbow_Attachment_Right

        public Transform elbowAttachmentLeft;
        public int elbowAttachmentLeftIndex;
        public int elbowAttachmentLeftTotal;
        
        #endregion

        #region All_09_Hips_Attachment

        public Transform hipsAttachment;
        public int hipsAttachmentIndex;
        public int hipsAttachmentTotal;

        #endregion

        #region All_10_Knee_Attachment_Right

        public Transform kneeAttachmentRight;
        public int kneeAttachmentRightIndex;
        public int kneeAttachmentRightTotal;

        #endregion
        
        #region All_11_Knee_Attachment_Left
        
        public Transform kneeAttachmentLeft;
        public int kneeAttachmentLeftIndex;
        public int kneeAttachmentLeftTotal;

        #endregion

        #region All_12_Extra

        public Transform elfEar;
        public int elfEarIndex;
        public int elfEarTotal;

        #endregion
        
        #region Character_Properties_Indizes

        public int headAllElementsIndex;
        public int headNoElementsIndex;
        public int eyebrowIndex;
        public int facialHairIndex;
        public int torsoIndex;
        public int armUpperRightIndex;
        public int armUpperLeftIndex;
        public int armLowerRightIndex;
        public int armLowerLeftIndex;
        public int handRightIndex;
        public int handLeftIndex;
        public int hipsIndex;
        public int legRightIndex;
        public int legLeftIndex;
        
        public int headAllElementsTotal;
        public int headNoElementsTotal;
        public int eyebrowTotal;
        public int facialHairTotal;
        public int torsoTotal;
        public int armUpperRightTotal;
        public int armUpperLeftTotal;
        public int armLowerRightTotal;
        public int armLowerLeftTotal;
        public int handRightTotal;
        public int handLeftTotal;
        public int hipsTotal;
        public int legRightTotal;
        public int legLeftTotal;
        
        #endregion

        #region Character_Properties_Transforms

        public Transform maleHeadAllElements;
        public Transform maleHeadNoElements;
        public Transform maleEyebrows;
        public Transform maleFacialHair;
        public Transform maleTorso;
        public Transform maleArmUpperRight;
        public Transform maleArmUpperLeft;
        public Transform maleArmLowerRight;
        public Transform maleArmLowerLeft;
        public Transform maleHandRight;
        public Transform maleHandLeft;
        public Transform maleHips;
        public Transform maleLegRight;
        public Transform maleLegLeft;
        public Transform femaleHeadAllElements;
        public Transform femaleHeadNoElements;
        public Transform femaleEyebrows;
        public Transform femaleFacialHair;
        public Transform femaleTorso;
        public Transform femaleArmUpperRight;
        public Transform femaleArmUpperLeft;
        public Transform femaleArmLowerRight;
        public Transform femaleArmLowerLeft;
        public Transform femaleHandRight;
        public Transform femaleHandLeft;
        public Transform femaleHips;
        public Transform femaleLegRight;
        public Transform femaleLegLeft;

        #endregion

        public Color primaryColor = new Color(0.2862745f, 0.4f, 0.4941177f);
        public Color secondaryColor = new Color(0.7019608f, 0.6235294f, 0.4666667f);
        public Color leatherPrimaryColor = new Color(0.28f, 0.21f, 0.16f);
        public Color leatherSecondaryColor = new Color(0.37f, 0.33f, 0.28f);
        public Color metalPrimaryColor = new Color(0.6705883f, 0.6705883f, 0.6705883f);
        public Color metalSecondaryColor = new Color(0.3921569f, 0.4039216f, 0.4117647f);
        public Color metalDarkColor = new Color(0.18f, 0.2f, 0.22f);
        public Color hairColor = new Color(0.3098039f, 0.254902f, 0.1764706f);
        public Color skinColor = new Color(1f, 0.8000001f, 0.682353f);
        public Color stubbleColor = new Color(0.8039216f, 0.7019608f, 0.6313726f);
        public Color scarColor = new Color(0.9294118f, 0.6862745f, 0.5921569f);
        public Color bodyArtColor = new Color(0.0509804f, 0.6745098f, 0.9843138f);
        public Color eyeColor = Color.black;
        
        public bool save;
        private SyntyCharacterData initSyntyCharacterData = new SyntyCharacterData();

        #endregion

        // INITIALIZERS: --------------------------------------------------------------------------

        #region Initializers

        protected override void Awake()
        {
            base.Awake();

            if (!Application.isPlaying) return;

            LoadCharacterTransforms();

            this.initSyntyCharacterData = new SyntyCharacterData()
            {
                gender = EnumGender.Male,
                headAllElementsIndex = 0,
                headNoElementsIndex = 0,
                eyebrowIndex = 0,
                torsoIndex = 0,
                facialHairIndex = 0,
                armUpperRightIndex = 0,
                armUpperLeftIndex = 0,
                armLowerRightIndex = 0,
                armLowerLeftIndex = 0,
                handRightIndex = 0,
                handLeftIndex = 0,
                hipsIndex = 0,
                legRightIndex = 0,
                legLeftIndex = 0,
                headCoveringsBaseHairIndex = 0,
                headCoveringsNoFacialHairIndex = 0,
                headCoveringsNoHairIndex = 0,
                hairIndex = 0,
                helmetIndex = 0,
                backAttackmentIndex = 0,
                shoulderAttachmentRightIndex = 0,
                shoudlerAttachmentLeftIndex = 0,
                elbowAttachmendRightIndex = 0,
                elbowAttachmentLeftIndex = 0,
                hipsAttachmentIndex = 0,
                kneeAttachmentRightIndex = 0,
                kneeAttachmentLeftIndex = 0,
                elfEarIndex = 0,
                primaryColor = this.primaryColor, 
                secondaryColor = this.secondaryColor, 
                leatherPrimaryColor = this.leatherPrimaryColor, 
                leatherSecondaryColor = this.leatherSecondaryColor, 
                metalPrimaryColor = this.metalPrimaryColor, 
                metalSecondaryColor = this.metalSecondaryColor, 
                metalDarkColor = this.metalDarkColor, 
                hairColor = this.hairColor, 
                skinColor = this.skinColor, 
                stubbleColor = this.stubbleColor, 
                scarColor = this.scarColor, 
                bodyArtColor = this.bodyArtColor, 
                eyeColor = this.eyeColor, 
            };

            if (this.save)
            {
                SaveLoadManager.Instance.Initialize(this);
            }
        }

        protected void OnDestroy()
        {
            this.OnDestroyGID();
            if (!Application.isPlaying) return;

            if (this.save && !this.exitingApplication)
            {
                SaveLoadManager.Instance.OnDestroyIGameSave(this);
            }
        }

        #endregion
        
        // UPDATE: --------------------------------------------------------------------------------

        #region Update

        protected override void OnValidate()
        {
            EditorApplication.delayCall += _OnValidate;
        }

        private void _OnValidate()
        {
            if (this == null) return;
            
            UpdateCharacterVisuals();
        }

        public void UpdateCharacterVisuals()
        {
            SetActiveInTransform(maleHeadAllElements, false);
            SetActiveInTransform(maleHeadNoElements, false);
            SetActiveInTransform(maleEyebrows, false);
            SetActiveInTransform(maleTorso, false);
            SetActiveInTransform(maleArmUpperRight, false);
            SetActiveInTransform(maleArmUpperLeft, false);
            SetActiveInTransform(maleArmLowerRight, false);
            SetActiveInTransform(maleArmLowerLeft, false);
            SetActiveInTransform(maleHandRight, false);
            SetActiveInTransform(maleHandLeft, false);
            SetActiveInTransform(maleHips, false);
            SetActiveInTransform(maleLegRight, false);
            SetActiveInTransform(maleLegLeft, false);
            SetActiveInTransform(maleFacialHair, false);
            
            SetActiveInTransform(femaleHeadAllElements, false);
            SetActiveInTransform(femaleHeadNoElements, false);
            SetActiveInTransform(femaleEyebrows, false);
            SetActiveInTransform(femaleTorso, false);
            SetActiveInTransform(femaleArmUpperRight, false);
            SetActiveInTransform(femaleArmUpperLeft, false);
            SetActiveInTransform(femaleArmLowerRight, false);
            SetActiveInTransform(femaleArmLowerLeft, false);
            SetActiveInTransform(femaleHandRight, false);
            SetActiveInTransform(femaleHandLeft, false);
            SetActiveInTransform(femaleHips, false);
            SetActiveInTransform(femaleLegRight, false);
            SetActiveInTransform(femaleLegLeft, false);
            SetActiveInTransform(femaleFacialHair, false);
            
            if (this.gender == EnumGender.Male)
            {
                SetActiveInTransform(maleHeadAllElements, true, headAllElementsIndex);
                SetActiveInTransform(maleHeadNoElements, true, headNoElementsIndex);
                SetActiveInTransform(maleEyebrows, true, eyebrowIndex);
                SetActiveInTransform(maleTorso, true, torsoIndex);
                SetActiveInTransform(maleArmUpperRight, true, armUpperRightIndex);
                SetActiveInTransform(maleArmUpperLeft, true, armUpperLeftIndex);
                SetActiveInTransform(maleArmLowerRight, true, armLowerRightIndex);
                SetActiveInTransform(maleArmLowerLeft, true, armLowerLeftIndex);
                SetActiveInTransform(maleHandRight, true, handRightIndex);
                SetActiveInTransform(maleHandLeft, true, handLeftIndex);
                SetActiveInTransform(maleHips, true, hipsIndex);
                SetActiveInTransform(maleLegRight, true, legRightIndex);
                SetActiveInTransform(maleLegLeft, true, legLeftIndex);
                SetActiveInTransform(maleFacialHair, true, facialHairIndex);
            }
            else
            {
                SetActiveInTransform(femaleHeadAllElements, true, headAllElementsIndex);
                SetActiveInTransform(femaleHeadNoElements, true, headNoElementsIndex);
                SetActiveInTransform(femaleEyebrows, true, eyebrowIndex);
                SetActiveInTransform(femaleTorso, true, torsoIndex);
                SetActiveInTransform(femaleArmUpperRight, true, armUpperRightIndex);
                SetActiveInTransform(femaleArmUpperLeft, true, armUpperLeftIndex);
                SetActiveInTransform(femaleArmLowerRight, true, armLowerRightIndex);
                SetActiveInTransform(femaleArmLowerLeft, true, armLowerLeftIndex);
                SetActiveInTransform(femaleHandRight, true, handRightIndex);
                SetActiveInTransform(femaleHandLeft, true, handLeftIndex);
                SetActiveInTransform(femaleHips, true, hipsIndex);
                SetActiveInTransform(femaleLegRight, true, legRightIndex);
                SetActiveInTransform(femaleLegLeft, true, legLeftIndex);
            }
            
            SetActiveInTransform(headCoveringsBaseHair, false);
            SetActiveInTransform(headCoveringsNoFacialHair, false);
            SetActiveInTransform(headCoveringsNoHair, false);
            SetActiveInTransform(hair, false);
            SetActiveInTransform(helmet, false);
            SetActiveInTransform(backAttackment, false);
            SetActiveInTransform(shoulderAttachmentRight, false);
            SetActiveInTransform(shoulderAttachmentLeft, false);
            SetActiveInTransform(elbowAttachmendRight, false);
            SetActiveInTransform(elbowAttachmentLeft, false);
            SetActiveInTransform(hipsAttachment, false);
            SetActiveInTransform(kneeAttachmentRight, false);
            SetActiveInTransform(kneeAttachmentLeft, false);
            SetActiveInTransform(elfEar, false);
            
            SetActiveInTransform(headCoveringsBaseHair, true, headCoveringsBaseHairIndex);
            SetActiveInTransform(headCoveringsNoFacialHair, true, headCoveringsNoFacialHairIndex);
            SetActiveInTransform(headCoveringsNoHair, true, headCoveringsNoHairIndex);
            SetActiveInTransform(hair, true, hairIndex);
            SetActiveInTransform(helmet, true, helmetIndex);
            SetActiveInTransform(backAttackment, true, backAttackmentIndex);
            SetActiveInTransform(shoulderAttachmentRight, true, shoulderAttachmentRightIndex);
            SetActiveInTransform(shoulderAttachmentLeft, true, shoudlerAttachmentLeftIndex);
            SetActiveInTransform(elbowAttachmendRight, true, elbowAttachmendRightIndex);
            SetActiveInTransform(elbowAttachmentLeft, true, elbowAttachmentLeftIndex);
            SetActiveInTransform(hipsAttachment, true, hipsAttachmentIndex);
            SetActiveInTransform(kneeAttachmentRight, true, kneeAttachmentRightIndex);
            SetActiveInTransform(kneeAttachmentLeft, true, kneeAttachmentLeftIndex);
            SetActiveInTransform(elfEar, true, elfEarIndex);

            ApplyColorToMaterial();
        }

        #endregion

        // PUBLIC METHODS: ------------------------------------------------------------------------

        public void BecomeMale()
        {
            ChangeGender(EnumGender.Male);
        }
        
        public void BecomeFemale()
        {
            ChangeGender(EnumGender.Female);
        }
        
        private void ChangeGender(EnumGender newGender)
        {
            this.gender = newGender;
            UpdateCharacterVisuals();
        }
        
        private static void SetActiveInTransform(Transform parent, bool active, int index = -1)
        {
            if (parent == null) return;
            
            int i = 0;
            foreach (Transform child in parent)
            {
                if(i == index || index == -1)
                    child.gameObject.SetActive(active);

                i++;
            }
        }

        private void ApplyColorToMaterial()
        {
            foreach (Renderer child in GetComponentsInChildren<Renderer>())
            {
                child.sharedMaterial.SetColor(Shader.PropertyToID("_Color_Primary"), primaryColor); 
                child.sharedMaterial.SetColor(Shader.PropertyToID("_Color_Secondary"), secondaryColor); 
                child.sharedMaterial.SetColor(Shader.PropertyToID("_Color_Leather_Primary"), leatherPrimaryColor); 
                child.sharedMaterial.SetColor(Shader.PropertyToID("_Color_Leather_Secondary"), leatherSecondaryColor); 
                child.sharedMaterial.SetColor(Shader.PropertyToID("_Color_Metal_Primary"), metalPrimaryColor); 
                child.sharedMaterial.SetColor(Shader.PropertyToID("_Color_Metal_Secondary"), metalSecondaryColor); 
                child.sharedMaterial.SetColor(Shader.PropertyToID("_Color_Metal_Dark"), metalDarkColor); 
                child.sharedMaterial.SetColor(Shader.PropertyToID("_Color_Hair"), hairColor); 
                child.sharedMaterial.SetColor(Shader.PropertyToID("_Color_Skin"), skinColor); 
                child.sharedMaterial.SetColor(Shader.PropertyToID("_Color_Stubble"), stubbleColor); 
                child.sharedMaterial.SetColor(Shader.PropertyToID("_Color_Scar"), scarColor); 
                child.sharedMaterial.SetColor(Shader.PropertyToID("_Color_BodyArt"), bodyArtColor); 
                child.sharedMaterial.SetColor(Shader.PropertyToID("_Color_Eyes"), eyeColor);
            }
        }
        
        // GAME SAVE: -----------------------------------------------------------------------------

        #region Game Save

        public string GetUniqueName()
        {
            string uniqueName = $"syntyCharacter:{this.GetUniqueCharacterID()}";

            return uniqueName;
        }
        
        private string GetUniqueCharacterID()
        {
            return this.GetID();
        }
        
        public Type GetSaveDataType()
        {
            return typeof(SyntyCharacterData);
        }
        
        public object GetSaveData()
        {
            Debug.Log("GetSaveData Fired");
            return new SyntyCharacterData()
            {
                gender = this.gender,
                headAllElementsIndex = this.headAllElementsIndex,
                headNoElementsIndex = this.headNoElementsIndex,
                eyebrowIndex = this.eyebrowIndex,
                facialHairIndex = this.facialHairIndex,
                torsoIndex = this.torsoIndex,
                armUpperRightIndex = this.armUpperRightIndex,
                armUpperLeftIndex = this.armUpperLeftIndex,
                armLowerRightIndex = this.armLowerRightIndex,
                armLowerLeftIndex = this.armLowerLeftIndex,
                handRightIndex = this.handRightIndex,
                handLeftIndex = this.handLeftIndex,
                hipsIndex = this.hipsIndex,
                legRightIndex = this.legRightIndex,
                legLeftIndex = this.legLeftIndex,
                headCoveringsBaseHairIndex = this.headCoveringsBaseHairIndex,
                headCoveringsNoFacialHairIndex = this.headCoveringsNoFacialHairIndex,
                headCoveringsNoHairIndex = this.headCoveringsNoHairIndex,
                hairIndex = this.hairIndex,
                helmetIndex = this.helmetIndex,
                backAttackmentIndex = this.backAttackmentIndex,
                shoulderAttachmentRightIndex = this.shoulderAttachmentRightIndex,
                shoudlerAttachmentLeftIndex = this.shoudlerAttachmentLeftIndex,
                elbowAttachmendRightIndex = this.elbowAttachmendRightIndex,
                elbowAttachmentLeftIndex = this.elbowAttachmentLeftIndex,
                hipsAttachmentIndex = this.hipsAttachmentIndex,
                kneeAttachmentRightIndex = this.kneeAttachmentRightIndex,
                kneeAttachmentLeftIndex = this.kneeAttachmentLeftIndex,
                elfEarIndex = this.elfEarIndex,
                primaryColor = this.primaryColor, 
                secondaryColor = this.secondaryColor, 
                leatherPrimaryColor = this.leatherPrimaryColor, 
                leatherSecondaryColor = this.leatherSecondaryColor, 
                metalPrimaryColor = this.metalPrimaryColor, 
                metalSecondaryColor = this.metalSecondaryColor, 
                metalDarkColor = this.metalDarkColor, 
                hairColor = this.hairColor, 
                skinColor = this.skinColor, 
                stubbleColor = this.stubbleColor, 
                scarColor = this.scarColor, 
                bodyArtColor = this.bodyArtColor, 
                eyeColor = this.eyeColor, 
            };
        }
        
        public void ResetData()
        {
            Debug.Log("ResetData Fired");
            
            gender = this.initSyntyCharacterData.gender;
            headAllElementsIndex = this.initSyntyCharacterData.headAllElementsIndex;
            headNoElementsIndex = this.initSyntyCharacterData.headNoElementsIndex;
            eyebrowIndex = this.initSyntyCharacterData.eyebrowIndex;
            facialHairIndex = this.initSyntyCharacterData.facialHairIndex;
            torsoIndex = this.initSyntyCharacterData.torsoIndex;
            armUpperRightIndex = this.initSyntyCharacterData.armUpperRightIndex;
            armUpperLeftIndex = this.initSyntyCharacterData.armUpperLeftIndex;
            armLowerRightIndex = this.initSyntyCharacterData.armLowerRightIndex;
            armLowerLeftIndex = this.initSyntyCharacterData.armLowerLeftIndex;
            handRightIndex = this.initSyntyCharacterData.handRightIndex;
            handLeftIndex = this.initSyntyCharacterData.handLeftIndex;
            hipsIndex = this.initSyntyCharacterData.hipsIndex;
            legRightIndex = this.initSyntyCharacterData.legRightIndex;
            legLeftIndex = this.initSyntyCharacterData.legLeftIndex;
            headCoveringsBaseHairIndex = this.initSyntyCharacterData.headCoveringsBaseHairIndex;
            headCoveringsNoFacialHairIndex = this.initSyntyCharacterData.headCoveringsNoFacialHairIndex;
            headCoveringsNoHairIndex = this.initSyntyCharacterData.headCoveringsNoHairIndex;
            hairIndex = this.initSyntyCharacterData.hairIndex;
            helmetIndex = this.initSyntyCharacterData.helmetIndex;
            backAttackmentIndex = this.initSyntyCharacterData.backAttackmentIndex;
            shoulderAttachmentRightIndex = this.initSyntyCharacterData.shoulderAttachmentRightIndex;
            shoudlerAttachmentLeftIndex = this.initSyntyCharacterData.shoudlerAttachmentLeftIndex;
            elbowAttachmendRightIndex = this.initSyntyCharacterData.elbowAttachmendRightIndex;
            elbowAttachmentLeftIndex = this.initSyntyCharacterData.elbowAttachmentLeftIndex;
            hipsAttachmentIndex = this.initSyntyCharacterData.hipsAttachmentIndex;
            kneeAttachmentRightIndex = this.initSyntyCharacterData.kneeAttachmentRightIndex;
            kneeAttachmentLeftIndex = this.initSyntyCharacterData.kneeAttachmentLeftIndex;
            elfEarIndex = this.initSyntyCharacterData.elfEarIndex;

            primaryColor = this.initSyntyCharacterData.primaryColor; 
            secondaryColor = this.initSyntyCharacterData.secondaryColor; 
            leatherPrimaryColor = this.initSyntyCharacterData.leatherPrimaryColor; 
            leatherSecondaryColor = this.initSyntyCharacterData.leatherSecondaryColor; 
            metalPrimaryColor = this.initSyntyCharacterData.metalPrimaryColor; 
            metalSecondaryColor = this.initSyntyCharacterData.metalSecondaryColor; 
            metalDarkColor = this.initSyntyCharacterData.metalDarkColor; 
            hairColor = this.initSyntyCharacterData.hairColor; 
            skinColor = this.initSyntyCharacterData.skinColor; 
            stubbleColor = this.initSyntyCharacterData.stubbleColor; 
            scarColor = this.initSyntyCharacterData.scarColor; 
            bodyArtColor = this.initSyntyCharacterData.bodyArtColor; 
            eyeColor = this.initSyntyCharacterData.eyeColor; 

            UpdateCharacterVisuals();
        }
        
        public void OnLoad(object generic)
        {
            Debug.Log("OnLoad Fired");
            
            SyntyCharacterData container = generic as SyntyCharacterData;
            if (container == null) return;
            
            Debug.Log("Have container");

            LoadCharacterTransforms();

            gender = container.gender;
            headAllElementsIndex = container.headAllElementsIndex;
            headNoElementsIndex = container.headNoElementsIndex;
            eyebrowIndex = container.eyebrowIndex;
            facialHairIndex = container.facialHairIndex;
            torsoIndex = container.torsoIndex;
            armUpperRightIndex = container.armUpperRightIndex;
            armUpperLeftIndex = container.armUpperLeftIndex;
            armLowerRightIndex = container.armLowerRightIndex;
            armLowerLeftIndex = container.armLowerLeftIndex;
            handRightIndex = container.handRightIndex;
            handLeftIndex = container.handLeftIndex;
            hipsIndex = container.hipsIndex;
            legRightIndex = container.legRightIndex;
            legLeftIndex = container.legLeftIndex;
            headCoveringsBaseHairIndex = container.headCoveringsBaseHairIndex;
            headCoveringsNoFacialHairIndex = container.headCoveringsNoFacialHairIndex;
            headCoveringsNoHairIndex = container.headCoveringsNoHairIndex;
            hairIndex = container.hairIndex;
            helmetIndex = container.helmetIndex;
            backAttackmentIndex = container.backAttackmentIndex;
            shoulderAttachmentRightIndex = container.shoulderAttachmentRightIndex;
            shoudlerAttachmentLeftIndex = container.shoudlerAttachmentLeftIndex;
            elbowAttachmendRightIndex = container.elbowAttachmendRightIndex;
            elbowAttachmentLeftIndex = container.elbowAttachmentLeftIndex;
            hipsAttachmentIndex = container.hipsAttachmentIndex;
            kneeAttachmentRightIndex = container.kneeAttachmentRightIndex;
            kneeAttachmentLeftIndex = container.kneeAttachmentLeftIndex;
            elfEarIndex = container.elfEarIndex;

            primaryColor = container.primaryColor;
            secondaryColor = container.secondaryColor;
            leatherPrimaryColor = container.leatherPrimaryColor;
            leatherSecondaryColor = container.leatherSecondaryColor;
            metalPrimaryColor = container.metalPrimaryColor;
            metalSecondaryColor = container.metalSecondaryColor;
            metalDarkColor = container.metalDarkColor;
            hairColor = container.hairColor;
            skinColor = container.skinColor;
            stubbleColor = container.stubbleColor;
            scarColor = container.scarColor;
            bodyArtColor = container.bodyArtColor;
            eyeColor = container.eyeColor;

            UpdateCharacterVisuals();
        }

        public void LoadCharacterTransforms()
        {
            maleHeadAllElements = this.gameObject.transform.FindDeepChild("Male_Head_All_Elements");
            maleHeadNoElements = this.gameObject.transform.FindDeepChild("Male_Head_No_Elements");
            maleEyebrows = this.gameObject.transform.FindDeepChild("Male_01_Eyebrows");
            maleFacialHair = this.gameObject.transform.FindDeepChild("Male_02_FacialHair");
            maleTorso = this.gameObject.transform.FindDeepChild("Male_03_Torso");
            maleArmUpperRight = this.gameObject.transform.FindDeepChild("Male_04_Arm_Upper_Right");
            maleArmUpperLeft = this.gameObject.transform.FindDeepChild("Male_05_Arm_Upper_Left");
            maleArmLowerRight = this.gameObject.transform.FindDeepChild("Male_06_Arm_Lower_Right");
            maleArmLowerLeft = this.gameObject.transform.FindDeepChild("Male_07_Arm_Lower_Left");
            maleHandRight = this.gameObject.transform.FindDeepChild("Male_08_Hand_Right");
            maleHandLeft = this.gameObject.transform.FindDeepChild("Male_09_Hand_Left");
            maleHips = this.gameObject.transform.FindDeepChild("Male_10_Hips");
            maleLegRight = this.gameObject.transform.FindDeepChild("Male_11_Leg_Right");
            maleLegLeft = this.gameObject.transform.FindDeepChild("Male_12_Leg_Left");
            femaleHeadAllElements = this.gameObject.transform.FindDeepChild("Female_Head_All_Elements");
            femaleHeadNoElements = this.gameObject.transform.FindDeepChild("Female_Head_No_Elements");
            femaleEyebrows = this.gameObject.transform.FindDeepChild("Female_01_Eyebrows");
            femaleFacialHair = this.gameObject.transform.FindDeepChild("Female_02_FacialHair");
            femaleTorso = this.gameObject.transform.FindDeepChild("Female_03_Torso");
            femaleArmUpperRight = this.gameObject.transform.FindDeepChild("Female_04_Arm_Upper_Right");
            femaleArmUpperLeft = this.gameObject.transform.FindDeepChild("Female_05_Arm_Upper_Left");
            femaleArmLowerRight = this.gameObject.transform.FindDeepChild("Female_06_Arm_Lower_Right");
            femaleArmLowerLeft = this.gameObject.transform.FindDeepChild("Female_07_Arm_Lower_Left");
            femaleHandRight = this.gameObject.transform.FindDeepChild("Female_08_Hand_Right");
            femaleHandLeft = this.gameObject.transform.FindDeepChild("Female_09_Hand_Left");
            femaleHips = this.gameObject.transform.FindDeepChild("Female_10_Hips");
            femaleLegRight = this.gameObject.transform.FindDeepChild("Female_11_Leg_Right");
            femaleLegLeft = this.gameObject.transform.FindDeepChild("Female_12_Leg_Left");
            headCoveringsBaseHair = this.gameObject.transform.FindDeepChild("HeadCoverings_Base_Hair");
            headCoveringsNoFacialHair = this.gameObject.transform.FindDeepChild("HeadCoverings_No_FacialHair");
            headCoveringsNoHair = this.gameObject.transform.FindDeepChild("HeadCoverings_No_Hair");
            hair = this.gameObject.transform.FindDeepChild("All_01_Hair");
            helmet = this.gameObject.transform.FindDeepChild("Helmet");
            backAttackment = this.gameObject.transform.FindDeepChild("All_04_Back_Attachment");
            shoulderAttachmentRight = this.gameObject.transform.FindDeepChild("All_05_Shoulder_Attachment_Right");
            shoulderAttachmentLeft = this.gameObject.transform.FindDeepChild("All_06_Shoulder_Attachment_Left");
            elbowAttachmendRight = this.gameObject.transform.FindDeepChild("All_07_Elbow_Attachment_Right");
            elbowAttachmentLeft = this.gameObject.transform.FindDeepChild("All_08_Elbow_Attachment_Left");
            hipsAttachment = this.gameObject.transform.FindDeepChild("All_09_Hips_Attachment");
            kneeAttachmentRight = this.gameObject.transform.FindDeepChild("All_10_Knee_Attachement_Right");
            kneeAttachmentLeft = this.gameObject.transform.FindDeepChild("All_11_Knee_Attachement_Left");
            elfEar = this.gameObject.transform.FindDeepChild("Elf_Ear");
            
            headAllElementsTotal = maleHeadAllElements.childCount;
            headNoElementsTotal = maleHeadNoElements.childCount;
            eyebrowTotal = maleEyebrows.childCount;
            torsoTotal = maleTorso.childCount;
            armUpperRightTotal = maleArmUpperRight.childCount;
            armUpperLeftTotal = maleArmUpperLeft.childCount;
            armLowerRightTotal = maleArmLowerRight.childCount;
            armLowerLeftTotal = maleArmLowerLeft.childCount;
            handRightTotal = maleHandRight.childCount;
            handLeftTotal = maleHandLeft.childCount;
            hipsTotal = maleHips.childCount;
            legRightTotal = maleLegRight.childCount;
            legLeftTotal = maleLegLeft.childCount;
            facialHairTotal = maleFacialHair.childCount;
            
            headCoveringsBaseHairTotal = headCoveringsBaseHair.childCount;
            headCoveringsNoFacialHairTotal = headCoveringsNoFacialHair.childCount;
            headCoveringsNoHairTotal = headCoveringsNoHair.childCount;
            hairTotal = hair.childCount;
            helmetTotal = helmet.childCount;
            backAttackmentTotal = backAttackment.childCount;
            shoulderAttachmentRightTotal = shoulderAttachmentRight.childCount;
            shoudlerAttachmentLeftTotal = shoulderAttachmentLeft.childCount;
            elbowAttachmendRightTotal = elbowAttachmendRight.childCount;
            elbowAttachmentLeftTotal = elbowAttachmentLeft.childCount;
            hipsAttachmentTotal = hipsAttachment.childCount;
            kneeAttachmentRightTotal = kneeAttachmentRight.childCount;
            kneeAttachmentLeftTotal = kneeAttachmentLeft.childCount;
            elfEarTotal = elfEar.childCount;
        }
        
        #endregion
    }
    
    public static class TransformDeepChildExtension
    {
        //Breadth-first search
        public static Transform FindDeepChild(this Transform aParent, string aName)
        {
            Queue<Transform> queue = new Queue<Transform>();
            queue.Enqueue(aParent);
            while (queue.Count > 0)
            {
                var c = queue.Dequeue();
                if (c.name == aName)
                    return c;
                foreach(Transform t in c)
                    queue.Enqueue(t);
            }
            return null;
        }
    }
}
