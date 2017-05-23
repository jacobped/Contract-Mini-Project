using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonSays
{
    public class DataProvider : IDataProvider
    {
        private IList<int> _sequence;
        private int _checkMarkPosition; // the sequence index

        public DataProvider()
        {
            _sequence = new List<int>();
            _checkMarkPosition = -1;
        }

        public IList<int> GetSequence()
        {
            return _sequence;
        }

        public bool MatchesWithCheckMarker(int item)
        {
            return (GetSequence()[GetCheckMarkerPosition()] == item);
        }

        public int GetCheckMarkerPosition()
        {
            return _checkMarkPosition;
        }

        public bool CanMoveCheckMarker()
        {
            return GetCheckMarkerPosition() < (GetSequence().Count - 1);
        }

        public void ClearSequence()
        {
            _sequence = new List<int>();
            ResetCheckMarker();
        }

        public void IncreaseSequenceLength(int maxExclusive)
        {
            _sequence.Add(maxExclusive-1 < 0 ? 1 : maxExclusive-1);
        }

        public void MoveCheckMarkerToNextPosition()
        {
            _checkMarkPosition++;
        }

        public void ResetCheckMarker()
        {
            _checkMarkPosition = -1;
        }
    }
}
