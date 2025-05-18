using System;
using System.Collections;
using System.Collections.Generic;
using Articy.Unity;
using BrothelGame.Windows;
using UnityEngine;

namespace BrothelGame.Infrastructure.Data
{
    [Serializable]
    public class DialogueData
    {
        public DialogueId Id;
        public ArticyRef Reference;
    }
}