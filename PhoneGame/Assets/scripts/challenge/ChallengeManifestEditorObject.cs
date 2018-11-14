using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App {
    /// <summary>
    /// Scriptable object which contains arrays of challenges by team distribution.
    /// </summary>
    [CreateAssetMenu(fileName = "New Challenge Manifest", menuName = "Challenge Manifest")]
    public class ChallengeManifestEditorObject : ScriptableObject {

        public ChallengeEditorObject[] OneVsOne, OneVsThree, TwoVsTwo, AllSolo, Solo;
    }
}
