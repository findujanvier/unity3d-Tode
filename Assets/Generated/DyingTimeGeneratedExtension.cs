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

        public DyingTime dyingTime { get { return (DyingTime)GetComponent(ComponentIds.DyingTime); } }
        public bool hasDyingTime { get { return HasComponent(ComponentIds.DyingTime); } }

        public Entity AddDyingTime(float newValue) {
            var component = CreateComponent<DyingTime>(ComponentIds.DyingTime);
            component.value = newValue;
            return AddComponent(ComponentIds.DyingTime, component);
        }

        public Entity ReplaceDyingTime(float newValue) {
            var component = CreateComponent<DyingTime>(ComponentIds.DyingTime);
            component.value = newValue;
            ReplaceComponent(ComponentIds.DyingTime, component);
            return this;
        }

        public Entity RemoveDyingTime() {
            return RemoveComponent(ComponentIds.DyingTime);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherDyingTime;

        public static IMatcher DyingTime {
            get {
                if(_matcherDyingTime == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.DyingTime);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherDyingTime = matcher;
                }

                return _matcherDyingTime;
            }
        }
    }
}
