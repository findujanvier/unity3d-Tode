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

        public TurnSpeed turnSpeed { get { return (TurnSpeed)GetComponent(ComponentIds.TurnSpeed); } }
        public bool hasTurnSpeed { get { return HasComponent(ComponentIds.TurnSpeed); } }

        public Entity AddTurnSpeed(float newValue) {
            var component = CreateComponent<TurnSpeed>(ComponentIds.TurnSpeed);
            component.value = newValue;
            return AddComponent(ComponentIds.TurnSpeed, component);
        }

        public Entity ReplaceTurnSpeed(float newValue) {
            var component = CreateComponent<TurnSpeed>(ComponentIds.TurnSpeed);
            component.value = newValue;
            ReplaceComponent(ComponentIds.TurnSpeed, component);
            return this;
        }

        public Entity RemoveTurnSpeed() {
            return RemoveComponent(ComponentIds.TurnSpeed);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherTurnSpeed;

        public static IMatcher TurnSpeed {
            get {
                if(_matcherTurnSpeed == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.TurnSpeed);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherTurnSpeed = matcher;
                }

                return _matcherTurnSpeed;
            }
        }
    }
}
