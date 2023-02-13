using System.Runtime.InteropServices;

namespace Apple.Arcade
{
    public static class FairPlay
    {
#if UNITY_STANDALONE_OSX && FAIR_PLAY_ENABLED
        [DllImport("FairPlayWrapper")]
        private static extern void DoRegisterAppWithFairPlay();
#endif
        public static void Register()
        {
#if UNITY_STANDALONE_OSX
    #if (!UNITY_EDITOR || FAIR_PLAY_IN_EDITOR) && FAIR_PLAY_ENABLED
        DoRegisterAppWithFairPlay();
    #else
        UnityEngine.Debug.LogWarning($"Apple.Arcade.FairPlay.Register() skipped as 'FAIR_PLAY_ENABLED' is not defined. Please ensure you define 'FAIR_PLAY_ENABLED' for any published Apple Arcade title.");
    #endif
#endif
        }
    }
}
