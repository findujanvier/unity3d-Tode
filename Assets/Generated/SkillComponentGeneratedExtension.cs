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

        public SkillComponent skill { get { return (SkillComponent)GetComponent(ComponentIds.Skill); } }
        public bool hasSkill { get { return HasComponent(ComponentIds.Skill); } }

        public Entity AddSkill(Node<string> newSkillNode) {
            var component = CreateComponent<SkillComponent>(ComponentIds.Skill);
            component.skillNode = newSkillNode;
            return AddComponent(ComponentIds.Skill, component);
        }

        public Entity ReplaceSkill(Node<string> newSkillNode) {
            var component = CreateComponent<SkillComponent>(ComponentIds.Skill);
            component.skillNode = newSkillNode;
            ReplaceComponent(ComponentIds.Skill, component);
            return this;
        }

        public Entity RemoveSkill() {
            return RemoveComponent(ComponentIds.Skill);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherSkill;

        public static IMatcher Skill {
            get {
                if(_matcherSkill == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Skill);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherSkill = matcher;
                }

                return _matcherSkill;
            }
        }
    }
}
