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

        static readonly ReachedEnd reachedEndComponent = new ReachedEnd();

        public bool isReachedEnd {
            get { return HasComponent(ComponentIds.ReachedEnd); }
            set {
                if(value != isReachedEnd) {
                    if(value) {
                        AddComponent(ComponentIds.ReachedEnd, reachedEndComponent);
                    } else {
                        RemoveComponent(ComponentIds.ReachedEnd);
                    }
                }
            }
        }

        public Entity IsReachedEnd(bool value) {
            isReachedEnd = value;
            return this;
        }
    }

    public partial class Matcher {

        static IMatcher _matcherReachedEnd;

        public static IMatcher ReachedEnd {
            get {
                if(_matcherReachedEnd == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.ReachedEnd);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherReachedEnd = matcher;
                }

                return _matcherReachedEnd;
            }
        }
    }
}
