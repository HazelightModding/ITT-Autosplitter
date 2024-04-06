using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using System.Reflection;
namespace LiveSplit.ItTakesTwo {
    public class ItTakesTwoFactory : IComponentFactory {
        public string ComponentName { get { return "It Takes Two Autosplitter v" + this.Version.ToString(); } }
        public string Description { get { return "Autosplitter for It Takes Two"; } }
        public ComponentCategory Category { get { return ComponentCategory.Control; } }
        public IComponent Create(LiveSplitState state) { return new ItTakesTwoComponent(state); }
        public string UpdateName { get { return this.ComponentName; } }
        public string UpdateURL { get { return "https://raw.githubusercontent.com/ITTSR/ITT-Autosplitter/main/"; } }
        public string XMLURL { get { return this.UpdateURL + "Components/LiveSplit.ItTakesTwo.Updates.xml"; } }
        public Version Version { get { return Assembly.GetExecutingAssembly().GetName().Version; } }
    }
}