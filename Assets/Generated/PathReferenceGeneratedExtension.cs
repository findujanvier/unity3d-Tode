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
        public PathReference pathReference { get { return (PathReference)GetComponent(ComponentIds.PathReference); } }

        public bool hasPathReference { get { return HasComponent(ComponentIds.PathReference); } }

        public Entity AddPathReference(Entitas.Entity newE) {
            var component = CreateComponent<PathReference>(ComponentIds.PathReference);
            component.e = newE;
            return AddComponent(ComponentIds.PathReference, component);
        }

        public Entity ReplacePathReference(Entitas.Entity newE) {
            var component = CreateComponent<PathReference>(ComponentIds.PathReference);
            component.e = newE;
            ReplaceComponent(ComponentIds.PathReference, component);
            return this;
        }

        public Entity RemovePathReference() {
            return RemoveComponent(ComponentIds.PathReference);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherPathReference;

        public static IMatcher PathReference {
            get {
                if (_matcherPathReference == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.PathReference);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherPathReference = matcher;
                }

                return _matcherPathReference;
            }
        }
    }
}
