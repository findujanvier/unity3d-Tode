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
        public Tower tower { get { return (Tower)GetComponent(ComponentIds.Tower); } }

        public bool hasTower { get { return HasComponent(ComponentIds.Tower); } }

        public Entity AddTower(string newTowerId) {
            var component = CreateComponent<Tower>(ComponentIds.Tower);
            component.towerId = newTowerId;
            return AddComponent(ComponentIds.Tower, component);
        }

        public Entity ReplaceTower(string newTowerId) {
            var component = CreateComponent<Tower>(ComponentIds.Tower);
            component.towerId = newTowerId;
            ReplaceComponent(ComponentIds.Tower, component);
            return this;
        }

        public Entity RemoveTower() {
            return RemoveComponent(ComponentIds.Tower);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTower;

        public static IMatcher Tower {
            get {
                if (_matcherTower == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Tower);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherTower = matcher;
                }

                return _matcherTower;
            }
        }
    }
}
