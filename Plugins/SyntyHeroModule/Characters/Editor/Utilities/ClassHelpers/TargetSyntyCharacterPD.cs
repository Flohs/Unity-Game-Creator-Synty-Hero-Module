using GameCreator.Core;
using GameCreator.Variables;
using UnityEditor;

namespace Synty.GameCreator.Characters
{
    [CustomPropertyDrawer(typeof(TargetSyntyCharacter))]
    public class TargetSyntyCharacterPD : TargetGenericPD
	{
        public const string PROP_CHARACTER = "character";
        public const string PROP_GLOBAL = "global";
        public const string PROP_LOCAL = "local";
        public const string PROP_LIST = "list";

        protected override SerializedProperty GetProperty(int option, SerializedProperty property)
        {
            TargetSyntyCharacter.Target optionTyped = (TargetSyntyCharacter.Target)option;
            switch (optionTyped)
            {
                case TargetSyntyCharacter.Target.Character:
                    return property.FindPropertyRelative(PROP_CHARACTER);

                case TargetSyntyCharacter.Target.LocalVariable:
                    return property.FindPropertyRelative(PROP_LOCAL);

                case TargetSyntyCharacter.Target.GlobalVariable:
                    return property.FindPropertyRelative(PROP_GLOBAL);

                case TargetSyntyCharacter.Target.ListVariable:
                    return property.FindPropertyRelative(PROP_LIST);
            }

            return null;
        }

        protected override void Initialize(SerializedProperty property)
        {
            int allowTypesMask = (1 << (int)Variable.DataType.GameObject);

            property
                .FindPropertyRelative(PROP_GLOBAL)
                .FindPropertyRelative(HelperGenericVariablePD.PROP_ALLOW_TYPES_MASK)
                .intValue = allowTypesMask;

            property
                .FindPropertyRelative(PROP_LOCAL)
                .FindPropertyRelative(HelperGenericVariablePD.PROP_ALLOW_TYPES_MASK)
                .intValue = allowTypesMask;
        }
    }
}