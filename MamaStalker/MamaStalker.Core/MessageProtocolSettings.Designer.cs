﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MamaStalker.Common {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class MessageProtocolSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static MessageProtocolSettings defaultInstance = ((MessageProtocolSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new MessageProtocolSettings())));
        
        public static MessageProtocolSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1024")]
        public int defualtPacketSize {
            get {
                return ((int)(this["defualtPacketSize"]));
            }
            set {
                this["defualtPacketSize"] = value;
            }
        }
    }
}
