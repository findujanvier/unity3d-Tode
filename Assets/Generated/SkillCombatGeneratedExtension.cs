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
        public SkillCombat skillCombat { get { return (SkillCombat)GetComponent(ComponentIds.SkillCombat); } }

        public bool hasSkillCombat { get { return HasComponent(ComponentIds.SkillCombat); } }

        public Entity AddSkillCombat(System.Collections.Generic.List<SkillEffect> newEffectList) {
            var component = CreateComponent<SkillCombat>(ComponentIds.SkillCombat);
            component.effectList = newEffectList;
            return AddComponent(ComponentIds.SkillCombat, component);
        }

        public Entity ReplaceSkillCombat(System.Collections.Generic.List<SkillEffect> newEffectList) {
            var component = CreateComponent<SkillCombat>(ComponentIds.SkillCombat);
            component.effectList = newEffectList;
            ReplaceComponent(ComponentIds.SkillCombat, component);
            return this;
        }

        public Entity RemoveSkillCombat() {
            return RemoveComponent(ComponentIds.SkillCombat);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherSkillCombat;

        public static IMatcher SkillCombat {
            get {
                if (_matcherSkillCombat == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.SkillCombat);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherSkillCombat = matcher;
                }

                return _matcherSkillCombat;
            }
        }
    }
}
