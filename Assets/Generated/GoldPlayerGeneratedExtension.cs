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

        public GoldPlayer goldPlayer { get { return (GoldPlayer)GetComponent(ComponentIds.GoldPlayer); } }
        public bool hasGoldPlayer { get { return HasComponent(ComponentIds.GoldPlayer); } }

        public Entity AddGoldPlayer(int newValue) {
            var component = CreateComponent<GoldPlayer>(ComponentIds.GoldPlayer);
            component.value = newValue;
            return AddComponent(ComponentIds.GoldPlayer, component);
        }

        public Entity ReplaceGoldPlayer(int newValue) {
            var component = CreateComponent<GoldPlayer>(ComponentIds.GoldPlayer);
            component.value = newValue;
            ReplaceComponent(ComponentIds.GoldPlayer, component);
            return this;
        }

        public Entity RemoveGoldPlayer() {
            return RemoveComponent(ComponentIds.GoldPlayer);
        }
    }

    public partial class Pool {

        public Entity goldPlayerEntity { get { return GetGroup(Matcher.GoldPlayer).GetSingleEntity(); } }
        public GoldPlayer goldPlayer { get { return goldPlayerEntity.goldPlayer; } }
        public bool hasGoldPlayer { get { return goldPlayerEntity != null; } }

        public Entity SetGoldPlayer(int newValue) {
            if(hasGoldPlayer) {
                throw new EntitasException("Could not set goldPlayer!\n" + this + " already has an entity with GoldPlayer!",
                    "You should check if the pool already has a goldPlayerEntity before setting it or use pool.ReplaceGoldPlayer().");
            }
            var entity = CreateEntity();
            entity.AddGoldPlayer(newValue);
            return entity;
        }

        public Entity ReplaceGoldPlayer(int newValue) {
            var entity = goldPlayerEntity;
            if(entity == null) {
                entity = SetGoldPlayer(newValue);
            } else {
                entity.ReplaceGoldPlayer(newValue);
            }

            return entity;
        }

        public void RemoveGoldPlayer() {
            DestroyEntity(goldPlayerEntity);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherGoldPlayer;

        public static IMatcher GoldPlayer {
            get {
                if(_matcherGoldPlayer == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.GoldPlayer);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherGoldPlayer = matcher;
                }

                return _matcherGoldPlayer;
            }
        }
    }
}
