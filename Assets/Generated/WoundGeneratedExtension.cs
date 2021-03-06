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

        static readonly Wound woundComponent = new Wound();

        public bool isWound {
            get { return HasComponent(ComponentIds.Wound); }
            set {
                if(value != isWound) {
                    if(value) {
                        AddComponent(ComponentIds.Wound, woundComponent);
                    } else {
                        RemoveComponent(ComponentIds.Wound);
                    }
                }
            }
        }

        public Entity IsWound(bool value) {
            isWound = value;
            return this;
        }
    }

    public partial class Matcher {

        static IMatcher _matcherWound;

        public static IMatcher Wound {
            get {
                if(_matcherWound == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Wound);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherWound = matcher;
                }

                return _matcherWound;
            }
        }
    }
}
