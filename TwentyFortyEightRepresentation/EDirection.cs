namespace TwentyFortyEightRepresentation
{
    public enum EDirection
    {
        Left,
        Up,
        Right,
        Down
    }

    public static class EDirectionsExtensions
    {
        public static bool IsVertical(this EDirection direction) => direction == EDirection.Down || direction == EDirection.Up;
    }
}