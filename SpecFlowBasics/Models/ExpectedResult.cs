﻿namespace SpecFlowBasics.Models
{
    public class ExpectedResult
    {
        public decimal ExpectedResults { get; set; }

        // Constructor (optional)
        public ExpectedResult(decimal expectedResult)
        {
            ExpectedResults = expectedResult;
        }

        // Default constructor (required for SpecFlow table binding)
        public ExpectedResult() { }

        // Override ToString for better readability (optional)
        public override string ToString()
        {
            return $"ExpectedResult: {ExpectedResults}";
        }
    }
}
