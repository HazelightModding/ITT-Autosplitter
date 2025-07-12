using LiveSplit.Model;
using LiveSplit.UI.Components;
using System;
using System.Reflection;
namespace LiveSplit.ItTakesTwo
{
    public class Factory : IComponentFactory
    {
        public string ComponentName => "It Takes Two Autosplitter v" + this.Version.ToString();
        public string Description => "Autosplitter for It Takes Two";
        public ComponentCategory Category => ComponentCategory.Control;
        public IComponent Create(LiveSplitState state) => new Component(state);
        public string UpdateName => this.ComponentName;
        public string UpdateURL => "https://raw.githubusercontent.com/ITTSR/ITT-Autosplitter/main/";
        public string XMLURL => this.UpdateURL + "Components/LiveSplit.ItTakesTwo.Updates.xml";
        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;
    }
}