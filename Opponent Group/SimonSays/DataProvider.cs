using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimonSays
{
    class DataProvider : IDataProvider
    {
        public IList<int> GetSequence()
        {
            throw new NotImplementedException();
        }

        public bool MatchesWithCheckMarker(int item)
        {
            throw new NotImplementedException();
        }

        public int GetCheckMarkerPosition()
        {
            throw new NotImplementedException();
        }

        public bool CanMoveCheckMarker()
        {
            throw new NotImplementedException();
        }

        public void ClearSequence()
        {
            throw new NotImplementedException();
        }

        public void IncreaseSequenceLength(int maxExclusive)
        {
            throw new NotImplementedException();
        }

        public void MoveCheckMarkerToNextPosition()
        {
            throw new NotImplementedException();
        }

        public void ResetCheckMarker()
        {
            throw new NotImplementedException();
        }
    }
}
