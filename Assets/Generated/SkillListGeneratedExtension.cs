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

        public SkillList skillList { get { return (SkillList)GetComponent(ComponentIds.SkillList); } }
        public bool hasSkillList { get { return HasComponent(ComponentIds.SkillList); } }

        public Entity AddSkillList(System.Collections.Generic.List<Tree<string>> newSkillTrees) {
            var component = CreateComponent<SkillList>(ComponentIds.SkillList);
            component.skillTrees = newSkillTrees;
            return AddComponent(ComponentIds.SkillList, component);
        }

        public Entity ReplaceSkillList(System.Collections.Generic.List<Tree<string>> newSkillTrees) {
            var component = CreateComponent<SkillList>(ComponentIds.SkillList);
            component.skillTrees = newSkillTrees;
            ReplaceComponent(ComponentIds.SkillList, component);
            return this;
        }

        public Entity RemoveSkillList() {
            return RemoveComponent(ComponentIds.SkillList);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherSkillList;

        public static IMatcher SkillList {
            get {
                if(_matcherSkillList == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.SkillList);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherSkillList = matcher;
                }

                return _matcherSkillList;
            }
        }
    }
}
