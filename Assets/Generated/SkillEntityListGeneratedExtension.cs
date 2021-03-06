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

        public SkillEntityList skillEntityList { get { return (SkillEntityList)GetComponent(ComponentIds.SkillEntityList); } }
        public bool hasSkillEntityList { get { return HasComponent(ComponentIds.SkillEntityList); } }

        public Entity AddSkillEntityList(System.Collections.Generic.List<Entitas.Entity> newSkillEntities) {
            var component = CreateComponent<SkillEntityList>(ComponentIds.SkillEntityList);
            component.skillEntities = newSkillEntities;
            return AddComponent(ComponentIds.SkillEntityList, component);
        }

        public Entity ReplaceSkillEntityList(System.Collections.Generic.List<Entitas.Entity> newSkillEntities) {
            var component = CreateComponent<SkillEntityList>(ComponentIds.SkillEntityList);
            component.skillEntities = newSkillEntities;
            ReplaceComponent(ComponentIds.SkillEntityList, component);
            return this;
        }

        public Entity RemoveSkillEntityList() {
            return RemoveComponent(ComponentIds.SkillEntityList);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherSkillEntityList;

        public static IMatcher SkillEntityList {
            get {
                if(_matcherSkillEntityList == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.SkillEntityList);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherSkillEntityList = matcher;
                }

                return _matcherSkillEntityList;
            }
        }
    }
}
