using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App {
    public class ChallengePicker : MonoBehaviour {

        // Static controller script instance
        public static ChallengePicker Instance;

        // Reference to the challenge manifest
        public ChallengeManifestEditorObject Manifest;

        // Use this for initialization
        void Awake() {
            // Put the single in singleton
            if (Instance == null) Instance = this;
            else if (Instance != this) Destroy(this);
        }

        /// <summary>
        /// Get a challenge from the manifest. 
        /// </summary>
        /// <param name="pType">Type of challenge to get.</param>
        public ChallengeEditorObject GetRandomChallengeByTeamType(TeamDistribution pType) {
            switch(pType) {
                default: return null;

                case TeamDistribution.ONE_V_ONE: return Manifest.OneVsOne[Random.Range(0, Manifest.OneVsOne.Length)];
                case TeamDistribution.ONE_V_THREE: return Manifest.OneVsOne[Random.Range(0, Manifest.OneVsThree.Length)];
                case TeamDistribution.TWO_V_TWO: return Manifest.OneVsOne[Random.Range(0, Manifest.TwoVsTwo.Length)];
                case TeamDistribution.ALL_SOLO: return Manifest.OneVsOne[Random.Range(0, Manifest.AllSolo.Length)];
                case TeamDistribution.SOLO: return Manifest.OneVsOne[Random.Range(0, Manifest.Solo.Length)];
            }
        }
    }
}
