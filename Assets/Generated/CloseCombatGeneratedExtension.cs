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

        public CloseCombat closeCombat { get { return (CloseCombat)GetComponent(ComponentIds.CloseCombat); } }
        public bool hasCloseCombat { get { return HasComponent(ComponentIds.CloseCombat); } }

        public Entity AddCloseCombat(Entitas.Entity newOpponent) {
            var component = CreateComponent<CloseCombat>(ComponentIds.CloseCombat);
            component.opponent = newOpponent;
            return AddComponent(ComponentIds.CloseCombat, component);
        }

        public Entity ReplaceCloseCombat(Entitas.Entity newOpponent) {
            var component = CreateComponent<CloseCombat>(ComponentIds.CloseCombat);
            component.opponent = newOpponent;
            ReplaceComponent(ComponentIds.CloseCombat, component);
            return this;
        }

        public Entity RemoveCloseCombat() {
            return RemoveComponent(ComponentIds.CloseCombat);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherCloseCombat;

        public static IMatcher CloseCombat {
            get {
                if(_matcherCloseCombat == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.CloseCombat);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherCloseCombat = matcher;
                }

                return _matcherCloseCombat;
            }
        }
    }
}
