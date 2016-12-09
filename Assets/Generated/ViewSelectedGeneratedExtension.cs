//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Entitas {

    public partial class Entity {

        public ViewSelected viewSelected { get { return (ViewSelected)GetComponent(ComponentIds.ViewSelected); } }
        public bool hasViewSelected { get { return HasComponent(ComponentIds.ViewSelected); } }

        public Entity AddViewSelected(UnityEngine.GameObject newIndicator) {
            var component = CreateComponent<ViewSelected>(ComponentIds.ViewSelected);
            component.indicator = newIndicator;
            return AddComponent(ComponentIds.ViewSelected, component);
        }

        public Entity ReplaceViewSelected(UnityEngine.GameObject newIndicator) {
            var component = CreateComponent<ViewSelected>(ComponentIds.ViewSelected);
            component.indicator = newIndicator;
            ReplaceComponent(ComponentIds.ViewSelected, component);
            return this;
        }

        public Entity RemoveViewSelected() {
            return RemoveComponent(ComponentIds.ViewSelected);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherViewSelected;

        public static IMatcher ViewSelected {
            get {
                if(_matcherViewSelected == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.ViewSelected);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherViewSelected = matcher;
                }

                return _matcherViewSelected;
            }
        }
    }
}
