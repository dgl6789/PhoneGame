using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App {
    /// <summary>
    /// Enumerator which serves to differentiate between challenges of differing team distributions
    /// </summary>
    public enum TeamDistribution { ONE_V_ONE, ONE_V_THREE, TWO_V_TWO, ALL_SOLO, SOLO }

    /// <summary>
    /// A scriptable object which represents a challenge. Information herein is parsed into the game
    /// UI when a challenge is chosen and activated.
    /// </summary>
    [CreateAssetMenu(fileName = "New Challenge", menuName = "Challenge")]
    public class ChallengeEditorObject : ScriptableObject {

        public string ChallengeString;
        public TeamDistribution Type;

        public string Description;
    }
}
