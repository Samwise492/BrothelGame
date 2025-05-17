using System.Collections;
using System.Collections.Generic;
using Articy.Unity;
using UnityEngine;

namespace BrothelGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = "DialogueData", menuName = "BrothelGame/DialogueData")]
    public class DialogueData : ScriptableObject
    {
        public ArticyReference refa;
    }
}