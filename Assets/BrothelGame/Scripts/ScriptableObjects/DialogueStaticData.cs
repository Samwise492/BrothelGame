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