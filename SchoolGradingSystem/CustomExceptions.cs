using System;

namespace SchoolGradingSystem
{
    // Custom exception for invalid score format
    public class InvalidScoreFormatException : Exception
    {
        public InvalidScoreFormatException(string message) : base(message)
        {
        }
    }

    // Custom exception for missing fields
    public class MissingFieldException : Exception
    {
        public MissingFieldException(string message) : base(message)
        {
        }
    }
}
