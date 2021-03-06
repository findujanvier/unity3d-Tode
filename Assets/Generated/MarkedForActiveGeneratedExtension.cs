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

        public MarkedForActive markedForActive { get { return (MarkedForActive)GetComponent(ComponentIds.MarkedForActive); } }
        public bool hasMarkedForActive { get { return HasComponent(ComponentIds.MarkedForActive); } }

        public Entity AddMarkedForActive(float newDelayTime) {
            var component = CreateComponent<MarkedForActive>(ComponentIds.MarkedForActive);
            component.delayTime = newDelayTime;
            return AddComponent(ComponentIds.MarkedForActive, component);
        }

        public Entity ReplaceMarkedForActive(float newDelayTime) {
            var component = CreateComponent<MarkedForActive>(ComponentIds.MarkedForActive);
            component.delayTime = newDelayTime;
            ReplaceComponent(ComponentIds.MarkedForActive, component);
            return this;
        }

        public Entity RemoveMarkedForActive() {
            return RemoveComponent(ComponentIds.MarkedForActive);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherMarkedForActive;

        public static IMatcher MarkedForActive {
            get {
                if(_matcherMarkedForActive == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.MarkedForActive);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherMarkedForActive = matcher;
                }

                return _matcherMarkedForActive;
            }
        }
    }
}
