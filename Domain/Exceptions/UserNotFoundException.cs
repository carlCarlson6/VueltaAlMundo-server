using System;

namespace Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public override String Message { get => String.Format( "can find the user with {0} = {1} ", this.fieldName, this.fieldValue); }
        private readonly String fieldName;
        private readonly String fieldValue;
        public UserNotFoundException(String fieldName, String fieldValue) : base()
        {
            this.fieldName = fieldName;
            this.fieldValue = fieldValue;
        }
    }
}
