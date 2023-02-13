using Apple.Core;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR_OSX
using UnityEditor.iOS.Xcode;
#endif

namespace Apple.Arcade.FairPlay.Editor
{
    public class AppleFairPlayBuildStep : AppleBuildStep
    {
        public override string DisplayName => "FairPlay";

        readonly Dictionary<BuildTarget, string> _libraryTable = new Dictionary<BuildTarget, string>
        {
            {BuildTarget.StandaloneOSX, "FairPlayWrapper.bundle"}
        };

#if UNITY_EDITOR_OSX
        public override void OnProcessFrameworks(AppleBuildProfile _, BuildTarget buildTarget, string pathToBuiltTarget, PBXProject pbxProject)
        {
            if (_libraryTable.ContainsKey(buildTarget))
            {
                string libraryName = _libraryTable[buildTarget];
                string libraryPath = AppleFrameworkUtility.GetPluginLibraryPathForBuildTarget(libraryName, buildTarget);
                if (String.IsNullOrEmpty(libraryPath))
                {
                    Debug.Log($"Failed to locate path for library: {libraryName}");
                }
                else
                {
                    AppleFrameworkUtility.CopyAndEmbed(libraryPath, buildTarget, pathToBuiltTarget, pbxProject);
                }
            }
            else
            {
                Debug.Log($"Processing {this.DisplayName} frameworks for unsupported platform. Skipping.");
            }
        }
#endif
    }
}
