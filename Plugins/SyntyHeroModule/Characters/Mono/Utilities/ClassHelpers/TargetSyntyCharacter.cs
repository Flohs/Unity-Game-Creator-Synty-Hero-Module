using System;
using GameCreator.Characters;
using GameCreator.Core.Hooks;
using GameCreator.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace Synty.GameCreator.Characters
{
    [Serializable]
	public class TargetSyntyCharacter
	{
		public enum Target
		{
			Player,
			Invoker,
			Character,
            LocalVariable,
            GlobalVariable,
            ListVariable
		}

        [Serializable]
        public class ChangeEvent : UnityEvent { }

        // PROPERTIES: ----------------------------------------------------------------------------

        public Target target = Target.Character;
        public SyntyCharacter character;
        public HelperLocalVariable local = new HelperLocalVariable();
        public HelperGlobalVariable global = new HelperGlobalVariable();
        public HelperGetListVariable list = new HelperGetListVariable();

        private int cacheInstanceID;
        private int cacheCharacterID;
        private SyntyCharacter cacheCharacter;

        public ChangeEvent eventChangeVariable = new ChangeEvent();

        // INITIALIZERS: --------------------------------------------------------------------------

        public TargetSyntyCharacter() { }

        public TargetSyntyCharacter(TargetSyntyCharacter.Target target)
        {
            this.target = target;
        }

		// PUBLIC METHODS: ------------------------------------------------------------------------

        public SyntyCharacter GetCharacter(GameObject invoker)
		{
            switch (this.target)
			{
    			case Target.Player :
                    if (HookPlayer.Instance != null) this.cacheCharacter = HookPlayer.Instance.Get<SyntyCharacter>();
    				break;

    			case Target.Invoker:
                    if (invoker == null)
                    {
                        this.cacheCharacter = null;
                        break;
                    }

                    if (this.cacheCharacter == null || invoker.GetInstanceID() != this.cacheCharacterID)
                    {
                        this.cacheCharacter = invoker.GetComponentInChildren<SyntyCharacter>();
                        this.cacheCharacterID = invoker.GetInstanceID();
                    }

                    if (this.cacheCharacter == null || invoker.GetInstanceID() != this.cacheCharacterID)
                    {
                        this.cacheCharacter = invoker.GetComponentInParent<SyntyCharacter>();
                        this.cacheCharacterID = invoker.GetInstanceID();
                    }

                    break;

                case Target.Character:
    				if (this.character != null) this.cacheCharacter = this.character;
    				break;

                case Target.LocalVariable:
                    GameObject localResult = this.local.Get(invoker) as GameObject;
                    if (localResult != null && localResult.GetInstanceID() != this.cacheInstanceID)
                    {
                        this.cacheCharacter = localResult.GetComponentInChildren<SyntyCharacter>();
                        if (this.cacheCharacter == null) localResult.GetComponentInParent<SyntyCharacter>();
                    }
                    break;

                case Target.GlobalVariable:
                    GameObject globalResult = this.global.Get(invoker) as GameObject;
                    if (globalResult != null && globalResult.GetInstanceID() != this.cacheInstanceID)
                    {
                        this.cacheCharacter = globalResult.GetComponentInChildren<SyntyCharacter>();
                        if (this.cacheCharacter == null) globalResult.GetComponentInParent<SyntyCharacter>();
                    }
                    break;

                case Target.ListVariable:
                    GameObject listResult = this.list.Get(invoker) as GameObject;
                    if (listResult != null && listResult.GetInstanceID() != this.cacheInstanceID)
                    {
                        this.cacheCharacter = listResult.GetComponentInChildren<SyntyCharacter>();
                        if (this.cacheCharacter == null) listResult.GetComponentInParent<SyntyCharacter>();
                    }
                    break;
            }

            this.cacheInstanceID = (this.cacheCharacter == null
                ? 0
                : this.cacheCharacter.gameObject.GetInstanceID()
            );

			return this.cacheCharacter;
		}

        // EVENTS: --------------------------------------------------------------------------------

        public void StartListeningVariableChanges(GameObject invoker)
        {
            switch (this.target)
            {
                case Target.GlobalVariable:
                    VariablesManager.events.SetOnChangeGlobal(
                        this.OnChangeVariable,
                        this.global.name
                    );
                    break;

                case Target.LocalVariable:
                    VariablesManager.events.SetOnChangeLocal(
                        this.OnChangeVariable,
                        this.local.GetGameObject(invoker),
                        this.local.name
                    );
                    break;

                case Target.ListVariable:
                    VariablesManager.events.StartListenListAny(
                        this.OnChangeVariable,
                        this.list.GetListVariables(invoker).gameObject
                    );
                    break;
            }
        }

        public void StopListeningVariableChanges(GameObject invoker)
        {
            switch (this.target)
            {
                case Target.GlobalVariable:
                    VariablesManager.events.RemoveChangeGlobal(
                        this.OnChangeVariable,
                        this.global.name
                    );
                    break;

                case Target.LocalVariable:
                    VariablesManager.events.RemoveChangeLocal(
                        this.OnChangeVariable,
                        this.local.GetGameObject(invoker),
                        this.local.name
                    );
                    break;

                case Target.ListVariable:
                    VariablesManager.events.StopListenListAny(
                        this.OnChangeVariable,
                        this.list.GetListVariables(invoker).gameObject
                    );
                    break;
            }
        }

        private void OnChangeVariable(string variableID)
        {
            this.eventChangeVariable.Invoke();
        }

        private void OnChangeVariable(int index, object prev, object next)
        {
            this.eventChangeVariable.Invoke();
        }

        // UTILITIES: -----------------------------------------------------------------------------

        public override string ToString ()
		{
			string result = "(unknown)";
			switch (this.target)
			{
    			case Target.Player : result = "Player"; break;
    			case Target.Invoker: result = "Invoker"; break;
                case Target.Character:
                    result = (this.character == null 
                        ? "(none)" 
                        : this.character.gameObject.name
                    );
    				break;
                case Target.LocalVariable: result = this.local.ToString(); break;
                case Target.GlobalVariable: result = this.global.ToString(); break;
                case Target.ListVariable: result = this.list.ToString(); break;
            }

			return result;
		}
	}
}