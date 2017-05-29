using TwentyFortyEightRepresentation.Board;

namespace TwentyFortyEightRepresentation.Model
{
    public struct Move
    {
        public Move(NewCell newCell, EDirection direction)
        {
            NewCell = newCell;
            Direction = direction;
        }

        public NewCell NewCell { get; }
        public EDirection Direction { get; }
    }
}