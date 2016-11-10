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
        public PointAttack pointAttack { get { return (PointAttack)GetComponent(ComponentIds.PointAttack); } }

        public bool hasPointAttack { get { return HasComponent(ComponentIds.PointAttack); } }

        public Entity AddPointAttack(UnityEngine.Vector3 newOffset) {
            var component = CreateComponent<PointAttack>(ComponentIds.PointAttack);
            component.offset = newOffset;
            return AddComponent(ComponentIds.PointAttack, component);
        }

        public Entity ReplacePointAttack(UnityEngine.Vector3 newOffset) {
            var component = CreateComponent<PointAttack>(ComponentIds.PointAttack);
            component.offset = newOffset;
            ReplaceComponent(ComponentIds.PointAttack, component);
            return this;
        }

        public Entity RemovePointAttack() {
            return RemoveComponent(ComponentIds.PointAttack);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherPointAttack;

        public static IMatcher PointAttack {
            get {
                if (_matcherPointAttack == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.PointAttack);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherPointAttack = matcher;
                }

                return _matcherPointAttack;
            }
        }
    }
}
