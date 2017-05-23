
namespace SimonSays
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    [ContractClass(typeof(AmazingContractDataProvider))]
    public interface IDataProvider
    {
        [Pure]
        IList<int> GetSequence();

        [Pure]
        bool MatchesWithCheckMarker(int item);

        [Pure]
        int GetCheckMarkerPosition();

        [Pure]
        bool CanMoveCheckMarker();

        void ClearSequence();

        void IncreaseSequenceLength(int maxExclusive);

        void MoveCheckMarkerToNextPosition();

        void ResetCheckMarker();
    }

    [ContractClassFor(typeof(IDataProvider))]
    public abstract class AmazingContractDataProvider : IDataProvider
    {
        [Pure]
        public IList<int> GetSequence()
        {
            return default(IList<int>);
        }

        [Pure]
        public int GetCheckMarkerPosition()
        {
            Contract.Ensures(Contract.Result<int>() < GetSequence().Count);
            Contract.Ensures(Contract.Result<int>() >= -1);
            Contract.Ensures(GetSequence().Count != 0 || Contract.Result<int>() == -1);
            return default(int);
        }

        [Pure]
        public bool MatchesWithCheckMarker(int item)
        {
            Contract.Requires(GetCheckMarkerPosition() != -1);
            Contract.Ensures(Contract.Result<bool>() == (GetSequence()[GetCheckMarkerPosition()] == item));
            return default(bool);
        }

        [Pure]
        public bool CanMoveCheckMarker()
        {
            Contract.Ensures(Contract.Result<bool>() == (GetCheckMarkerPosition() < GetSequence().Count - 1));
            return default(bool);
        }



        public void ClearSequence()
        {
            Contract.Ensures(GetSequence().Count == 0);
            Contract.Ensures(GetCheckMarkerPosition() == -1);
        }

        public void IncreaseSequenceLength(int maxExclusive)
        {
            Contract.Ensures(Contract.OldValue(GetSequence().ToList()).Count == GetSequence().Count - 1);
            Contract.Ensures(
                Contract.ForAll(0, Contract.OldValue(GetSequence().ToList()).Count,
                    index => Contract.OldValue(GetSequence().ToList())[index] == GetSequence()[index])
            );
            // Below is a weird rule, because The last condition is not for the old value, but the newest Is this right?
            Contract.Ensures(GetSequence().Last() > 0 && GetSequence().Last() < maxExclusive);
        }

        public void MoveCheckMarkerToNextPosition()
        {
            Contract.Requires(Contract.OldValue(GetCheckMarkerPosition()) < GetSequence().Count - 1); // Error OldValue() can be used only in Ensures.
            Contract.Ensures(Contract.OldValue(GetCheckMarkerPosition()) == GetCheckMarkerPosition() - 1);
        }

        public void ResetCheckMarker()
        {
            Contract.Ensures(GetCheckMarkerPosition() == -1);
        }

    }
}
