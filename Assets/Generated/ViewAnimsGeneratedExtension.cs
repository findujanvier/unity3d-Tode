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

        public ViewAnims viewAnims { get { return (ViewAnims)GetComponent(ComponentIds.ViewAnims); } }
        public bool hasViewAnims { get { return HasComponent(ComponentIds.ViewAnims); } }

        public Entity AddViewAnims(UnityEngine.Animator[] newAnims) {
            var component = CreateComponent<ViewAnims>(ComponentIds.ViewAnims);
            component.anims = newAnims;
            return AddComponent(ComponentIds.ViewAnims, component);
        }

        public Entity ReplaceViewAnims(UnityEngine.Animator[] newAnims) {
            var component = CreateComponent<ViewAnims>(ComponentIds.ViewAnims);
            component.anims = newAnims;
            ReplaceComponent(ComponentIds.ViewAnims, component);
            return this;
        }

        public Entity RemoveViewAnims() {
            return RemoveComponent(ComponentIds.ViewAnims);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherViewAnims;

        public static IMatcher ViewAnims {
            get {
                if(_matcherViewAnims == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.ViewAnims);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherViewAnims = matcher;
                }

                return _matcherViewAnims;
            }
        }
    }
}
