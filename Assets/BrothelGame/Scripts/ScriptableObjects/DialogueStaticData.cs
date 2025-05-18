using System.Collections;
using System.Collections.Generic;
using Articy.Unity;
using BrothelGame.Infrastructure.Data;
using UnityEngine;

namespace BrothelGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = "DialogueStaticData", menuName = "BrothelGame/DialogueStaticData")]
    public class DialogueStaticData : ScriptableObject
    {
        public DialogueData[] Dialogues;
    }
}