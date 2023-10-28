using DF.Data;

namespace DF.Model
{
    internal struct PlayerModel
    {
        internal float Speed;
        internal float MovementSmoothing;

        internal PlayerModel(PlayerConfig config)
        {
            Speed = config.Speed;
            MovementSmoothing = config.MovementSmoothing;
        }
    }
}
