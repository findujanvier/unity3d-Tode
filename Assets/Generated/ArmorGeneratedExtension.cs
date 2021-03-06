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

        public Armor armor { get { return (Armor)GetComponent(ComponentIds.Armor); } }
        public bool hasArmor { get { return HasComponent(ComponentIds.Armor); } }

        public Entity AddArmor(System.Collections.Generic.List<ArmorData> newArmorList) {
            var component = CreateComponent<Armor>(ComponentIds.Armor);
            component.armorList = newArmorList;
            return AddComponent(ComponentIds.Armor, component);
        }

        public Entity ReplaceArmor(System.Collections.Generic.List<ArmorData> newArmorList) {
            var component = CreateComponent<Armor>(ComponentIds.Armor);
            component.armorList = newArmorList;
            ReplaceComponent(ComponentIds.Armor, component);
            return this;
        }

        public Entity RemoveArmor() {
            return RemoveComponent(ComponentIds.Armor);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherArmor;

        public static IMatcher Armor {
            get {
                if(_matcherArmor == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Armor);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherArmor = matcher;
                }

                return _matcherArmor;
            }
        }
    }
}
