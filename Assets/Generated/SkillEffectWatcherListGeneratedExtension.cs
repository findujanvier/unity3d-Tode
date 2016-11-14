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

        public SkillEffectWatcherList skillEffectWatcherList { get { return (SkillEffectWatcherList)GetComponent(ComponentIds.SkillEffectWatcherList); } }
        public bool hasSkillEffectWatcherList { get { return HasComponent(ComponentIds.SkillEffectWatcherList); } }

        public Entity AddSkillEffectWatcherList(System.Collections.Generic.List<Entitas.Entity> newWatchers) {
            var component = CreateComponent<SkillEffectWatcherList>(ComponentIds.SkillEffectWatcherList);
            component.watchers = newWatchers;
            return AddComponent(ComponentIds.SkillEffectWatcherList, component);
        }

        public Entity ReplaceSkillEffectWatcherList(System.Collections.Generic.List<Entitas.Entity> newWatchers) {
            var component = CreateComponent<SkillEffectWatcherList>(ComponentIds.SkillEffectWatcherList);
            component.watchers = newWatchers;
            ReplaceComponent(ComponentIds.SkillEffectWatcherList, component);
            return this;
        }

        public Entity RemoveSkillEffectWatcherList() {
            return RemoveComponent(ComponentIds.SkillEffectWatcherList);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherSkillEffectWatcherList;

        public static IMatcher SkillEffectWatcherList {
            get {
                if(_matcherSkillEffectWatcherList == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.SkillEffectWatcherList);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherSkillEffectWatcherList = matcher;
                }

                return _matcherSkillEffectWatcherList;
            }
        }
    }
}
