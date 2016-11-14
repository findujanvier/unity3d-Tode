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

        public LifePlayer lifePlayer { get { return (LifePlayer)GetComponent(ComponentIds.LifePlayer); } }
        public bool hasLifePlayer { get { return HasComponent(ComponentIds.LifePlayer); } }

        public Entity AddLifePlayer(int newValue) {
            var component = CreateComponent<LifePlayer>(ComponentIds.LifePlayer);
            component.value = newValue;
            return AddComponent(ComponentIds.LifePlayer, component);
        }

        public Entity ReplaceLifePlayer(int newValue) {
            var component = CreateComponent<LifePlayer>(ComponentIds.LifePlayer);
            component.value = newValue;
            ReplaceComponent(ComponentIds.LifePlayer, component);
            return this;
        }

        public Entity RemoveLifePlayer() {
            return RemoveComponent(ComponentIds.LifePlayer);
        }
    }

    public partial class Pool {

        public Entity lifePlayerEntity { get { return GetGroup(Matcher.LifePlayer).GetSingleEntity(); } }
        public LifePlayer lifePlayer { get { return lifePlayerEntity.lifePlayer; } }
        public bool hasLifePlayer { get { return lifePlayerEntity != null; } }

        public Entity SetLifePlayer(int newValue) {
            if(hasLifePlayer) {
                throw new EntitasException("Could not set lifePlayer!\n" + this + " already has an entity with LifePlayer!",
                    "You should check if the pool already has a lifePlayerEntity before setting it or use pool.ReplaceLifePlayer().");
            }
            var entity = CreateEntity();
            entity.AddLifePlayer(newValue);
            return entity;
        }

        public Entity ReplaceLifePlayer(int newValue) {
            var entity = lifePlayerEntity;
            if(entity == null) {
                entity = SetLifePlayer(newValue);
            } else {
                entity.ReplaceLifePlayer(newValue);
            }

            return entity;
        }

        public void RemoveLifePlayer() {
            DestroyEntity(lifePlayerEntity);
        }
    }

    public partial class Matcher {

        static IMatcher _matcherLifePlayer;

        public static IMatcher LifePlayer {
            get {
                if(_matcherLifePlayer == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.LifePlayer);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherLifePlayer = matcher;
                }

                return _matcherLifePlayer;
            }
        }
    }
}
